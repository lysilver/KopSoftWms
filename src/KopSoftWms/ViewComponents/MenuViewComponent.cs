using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YL.Core.Dto;
using YL.Utils.Extensions;

namespace KopSoftWms.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ISys_roleServices _roleServices;
        private readonly IHttpContextAccessor _httpContext;

        public MenuViewComponent(ISys_roleServices roleServices,
            IHttpContextAccessor httpContext)
        {
            _roleServices = roleServices;
            _httpContext = httpContext;
        }

        //public IViewComponentResult Invoke()
        //{
        //    var claims = _httpContext.HttpContext.User.Claims;
        //    var roleId = claims.SingleOrDefault(c => c.Type == ClaimTypes.Role).Value.ToInt64();
        //    var menu = _roleServices.GetMenu(roleId);
        //    return View(menu);
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claims = _httpContext.HttpContext.User.Claims;
            var roleId = claims.SingleOrDefault(c => c.Type == ClaimTypes.Role).Value.ToInt64();
            var menus = await GetItemsAsync(roleId);
            //var sd = await _roleServices.GetMenu(roleId).ToListAsync();
            return View(menus);
        }

        private Task<List<PermissionMenu>> GetItemsAsync(long roleId)
        {
            Task<List<PermissionMenu>> t1 = Task.Factory.StartNew(() => _roleServices.GetMenu(roleId));
            return t1;
        }
    }
}