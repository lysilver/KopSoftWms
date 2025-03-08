﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace YL.NetCore.Attributes
{
    /// <summary>
    /// ConsumesAttribute
    /// </summary>
    public class AddHeaderAttribute : ResultFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public AddHeaderAttribute(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Append(
                _name, new string[] { _value });
            base.OnResultExecuting(context);
        }
    }
}