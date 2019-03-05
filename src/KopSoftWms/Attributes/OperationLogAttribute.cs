using IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Claims;
using YL.Core.Entity.Fluent.Validation;
using YL.Utils.Env;
using YL.Utils.Extensions;
using YL.Utils.Http;
using YL.Utils.Pub;

namespace YL.NetCore.Attributes
{
    public sealed class OperationLogAttribute : ResultFilterAttribute
    {
        public bool Ignore { get; set; } = true;
        public LogType LogType { get; set; }

        public OperationLogAttribute()
        {
        }

        public OperationLogAttribute(bool ignore)
        {
            Ignore = ignore;
        }

        public OperationLogAttribute(LogType logType)
        {
            LogType = logType;
        }

        public OperationLogAttribute(bool ignore, LogType logType)
        {
            Ignore = ignore;
            LogType = logType;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var services = context.HttpContext.RequestServices;
            var config = services.GetService(typeof(IConfiguration)) as IConfiguration;
            var claims = context.HttpContext.User.Claims;
            string flag = config["Log:operationlog"];
            if (string.IsNullOrWhiteSpace(flag))
            {
                flag = "false";
            }
            if (flag.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                if (Ignore)
                {//传入参数
                    var parameters = context.ReadResultExecutingContext();
                    //result
                    var result = context.Result;
                    object res = null;
                    if (result is ObjectResult objectResult)
                    {
                        res = objectResult.Value;
                    }
                    else if (result is ContentResult contentResult)
                    {
                        res = contentResult.Content;
                    }
                    else if (result is EmptyResult emptyResult)
                    {
                        res = emptyResult;
                    }
                    else if (result is StatusCodeResult statusCodeResult)
                    {
                        res = statusCodeResult;
                    }
                    else if (result is JsonResult jsonResult)
                    {
                        res = jsonResult.Value.ToString();
                    }
                    else if (result is FileResult fileResult)
                    {
                        res = fileResult.FileDownloadName.IsEmpty() ? fileResult.ContentType : fileResult.FileDownloadName;
                    }
                    else if (result is ViewResult viewResult)
                    {
                        res = viewResult.Model;
                    }
                    else if (result is RedirectResult redirectResult)
                    {
                        res = redirectResult.Url;
                    }
                    var log = services.GetService(typeof(ISys_logServices)) as ISys_logServices;
                    if (LogType == LogType.addOrUpdate)
                    {
                        if (res.ToString().Contains("修改"))
                        {
                            LogType = LogType.update;
                        }
                        if (res.ToString().Contains("添加"))
                        {
                            LogType = LogType.add;
                        }
                    }
                    string des = "";
                    if (LogType == LogType.select)
                    {
                        des = parameters.Item1 + ";" + parameters.Item3;
                    }
                    else
                    {
                        des = res.ToString() + ";" + parameters.Item1 + ";" + parameters.Item3;
                    }
                    var model = new Core.Entity.Sys_log
                    {
                        Browser = GlobalCore.GetBrowser(),
                        CreateBy = claims.SingleOrDefault(c => c.Type == ClaimTypes.Sid).Value.ToInt64(),
                        CreateDate = DateTimeExt.DateTime,
                        Description = des,
                        LogId = PubId.SnowflakeId,
                        LogIp = GlobalCore.GetIp(),
                        LogType = LogType.EnumToString(),
                        Url = parameters.Item2
                    };
                    SysLogFluent rules = new SysLogFluent();
                    var validationResult = rules.Validate(model);
                    if (validationResult.IsValid)
                    {
                        log.Insert(model);
                    }
                }
            }
            base.OnResultExecuting(context);
        }
    }
}