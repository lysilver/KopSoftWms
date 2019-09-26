using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;
using System.Reflection;
using YL.NetCore.Attributes;

namespace YL.NetCore.Conventions
{
    /// <summary>
    /// 注册约定
    /// </summary>
    public class NotFoundResultFilterConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (IsApiController(controller))
            {
                controller.Filters.Add(new NotFoundResultFilterAttribute());
            }
        }

        private static bool IsApiController(ControllerModel controller)
        {
            //IApiBehaviorMetadata
            if (controller.Attributes.OfType<ApiControllerAttribute>().Any())
            {
                return true;
            }
            return controller.ControllerType.Assembly.GetCustomAttributes().OfType<ApiControllerAttribute>().Any();
        }
    }
}