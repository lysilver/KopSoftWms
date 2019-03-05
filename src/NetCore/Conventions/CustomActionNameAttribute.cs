using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace YL.NetCore.Conventions
{
    /// <summary>
    /// 修改Action的名称 该属性也会覆盖 MVC 使用该方法名称的约定
    /// </summary>
    public class CustomActionNameAttribute : Attribute, IActionModelConvention
    {
        private readonly string _actionName;

        public CustomActionNameAttribute(string actionName)
        {
            _actionName = actionName;
        }

        public void Apply(ActionModel action)
        {
            action.ActionName = _actionName;
        }
    }
}