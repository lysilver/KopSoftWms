using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace YL.NetCore.Attributes
{
    /// <summary>
    /// 恶意IP
    /// 使用方法 [ServiceFilter(typeof(ClientIpCheckFilter))]
    /// </summary>
    public class ClientIpCheckFilter : ActionFilterAttribute
    {
        private readonly IConfiguration _configuration;

        public ClientIpCheckFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var remoteIp = context.HttpContext.Connection.RemoteIpAddress;
            var bytes = remoteIp.GetAddressBytes();
            //数据库中取出恶意ip
            var badIp = true;
            var testIp = IPAddress.Parse("127.0.0.1");
            badIp = false;
            var list = new List<string>();
            foreach (var item in list)
            {
                if (testIp.GetAddressBytes().SequenceEqual(bytes))
                {
                    badIp = false;
                    break;
                }
            }
            if (badIp)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}