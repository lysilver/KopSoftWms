using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace YL.NetCore.Attributes
{
    /// <summary>
    /// https://www.strathweb.com/2018/10/convert-null-valued-results-to-404-in-asp-net-core-mvc/
    /// </summary>
    public class NotFoundResultFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value == null)
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}