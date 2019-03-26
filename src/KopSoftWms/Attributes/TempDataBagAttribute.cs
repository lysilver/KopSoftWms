using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KopSoftWms.Attributes
{
    /// <summary>
    /// ViewBag ViewData TempData
    /// </summary>
    public class TempDataBagAttribute : ActionFilterAttribute
    {
        public TempDataBagAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var viewData = (context.Controller as Controller)?.ViewData;
            var viewBag = (context.Controller as Controller)?.ViewBag;
            var tempData = (context.Controller as Controller)?.TempData;
            var services = context.HttpContext.RequestServices;
            var properties = context.ActionDescriptor.Properties;
            var claims = context.HttpContext.User?.Claims;
            var cache = services.GetService(typeof(IMemoryCache)) as IMemoryCache;
            if (viewData != null)
            {
            }
            if (viewBag != null)
            {
                viewBag.title = properties["title"].ToString();
                viewBag.company = properties["company"].ToString();
                viewBag.customer = properties["customer"].ToString();
            }
            base.OnActionExecuting(context);
        }
    }
}