using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using YL.Utils.Log;
using YL.Utils.Json;

namespace YL.NetCore.Attributes
{
    public class BaseExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly ILogUtil _logUtil;
        private readonly IConfiguration _configuration;

        public BaseExceptionAttribute(ILogUtil logUtil, IConfiguration configuration)
        {
            _logUtil = logUtil;
            _configuration = configuration;
        }

        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var header = context.HttpContext.Request.Headers["promise"];
                //context.Exception.WriteToFile();
                var data = context.RouteData;
                var areaName = data.Values["area"];
                var controllerName = data.Values["controller"];
                var actionName = data.Values["action"];
                var dt = context.Exception;
                //错误日志
                string flag = _configuration["Log:errorlog"];
                if (flag.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    _logUtil.Debug(dt, $"{areaName}/{controllerName}/{actionName}");
                }
                //Task.Factory.StartNew(() =>
                //{
                //    _logUtil.Debug(dt, dt.Message);
                //});
                //context.HttpContext.Response.StatusCode = 404;
                //context.HttpContext.Response.Redirect("/Home/Error");
                //context.HttpContext.Response.Redirect("404.html");
                if (header == "promise")
                {
                    context.Result = new ContentResult()
                    {
                        //Content = (false, "异常").JilToJson()
                        Content = (false, dt.Message).JilToJson()
                    };
                }
                else if (context.HttpContext.Request.Headers["fileExcel"] == "fileExcel")
                {
                    context.Result = new ContentResult()
                    {
                        Content = (false, "文件可能已损坏").JilToJson()
                    };
                }
                else
                {
                    context.Result = new RedirectResult("/Home/Error");
                }
                context.ExceptionHandled = true;
            }
            base.OnException(context);
        }
    }
}