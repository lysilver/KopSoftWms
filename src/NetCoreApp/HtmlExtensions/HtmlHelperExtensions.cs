using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YL.NetCore.HtmlExtensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString A(this IHtmlHelper helper)
        {
            return new HtmlString(helper.ViewContext.RouteData.Values["area"].ToString());
        }

        public static HtmlString C(this IHtmlHelper helper)
        {
            return new HtmlString(helper.ViewContext.RouteData.Values["Controller"].ToString());
        }

        public static HtmlString T(this IHtmlHelper helper)
        {
            return new HtmlString(helper.ViewContext.RouteData.Values["Action"].ToString());
        }

        public static HtmlString AC(this IHtmlHelper helper)
        {
            var areaName = helper.ViewContext.RouteData.Values["area"].ToString();
            var controllerName = helper.ViewContext.RouteData.Values["Controller"].ToString();
            var actionName = helper.ViewContext.RouteData.Values["Action"].ToString();
            return new HtmlString("/" + areaName + "/" + controllerName + "/" + actionName);
        }
    }
}