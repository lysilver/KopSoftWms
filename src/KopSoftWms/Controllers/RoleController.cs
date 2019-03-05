using FluentValidation.Results;
using IServices;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Linq;
using YL.Core.Dto;
using YL.Core.Entity;
using YL.Core.Entity.Fluent.Validation;
using YL.NetCore.Attributes;
using YL.NetCore.NetCoreApp;
using YL.Utils.Extensions;
using YL.Utils.Pub;
using YL.Utils.Table;

namespace KopSoftWms.Controllers
{
    public class RoleController : BaseController
    {
        private readonly ISys_menuServices _menuServices;
        private readonly ISys_roleServices _roleServices;
        private readonly ISys_rolemenuServices _rolemenuServices;
        private readonly ISys_userServices _userServices;

        public RoleController(ISys_userServices userServices, ISys_rolemenuServices rolemenuServices, ISys_roleServices roleServices, ISys_menuServices menuServices)
        {
            _userServices = userServices;
            _menuServices = menuServices;
            _roleServices = roleServices;
            _rolemenuServices = rolemenuServices;
        }

        [CheckMenu]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [OperationLog(LogType.select)]
        public ContentResult List([FromForm]Bootstrap.BootstrapParams bootstrap)
        {
            var sd = _roleServices.PageList(bootstrap);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult GetMenuList()
        {
            //var permissionMenus = _menuServices.QueryableToList(c => c.IsDel == 1 && c.MenuType == "menu" && c.Status == 1);
            //var parentPermissions = permissionMenus.Where(a => a.MenuParent == -1).ToList();
            //var ret = new List<PermissionMenu>();
            //parentPermissions.ForEach(p =>
            //{
            //    PermissionMenu permissionMenu = PermissionMenu.Create(p);
            //    permissionMenu.Children = permissionMenus
            //    .Where(c => c.MenuParent == p.MenuId)
            //    .Select(m => new PermissionMenu()
            //    {
            //        Id = m.MenuId.ToString(),
            //        Name = m.MenuName,
            //        Icon = m.MenuIcon,
            //        Url = m.MenuUrl,
            //        ParentId = m.MenuParent.ToString()
            //    }).ToList();
            //    ret.Add(permissionMenu);
            //});
            return BootJsonH(_roleServices.GetMenu());
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            var roles = new RoleMenuDto();
            if (id.IsEmpty())
            {
                return View(roles);
            }
            else
            {
                var role = _roleServices.QueryableToEntity(c => c.RoleId == SqlFunc.ToInt64(id));
                var list = _rolemenuServices.QueryableToList(c => c.RoleId == SqlFunc.ToInt64(id));
                roles = new RoleMenuDto()
                {
                    RoleId = role?.RoleId.ToString(),
                    RoleName = role?.RoleName,
                    RoleType = role?.RoleType,
                    Remark = role?.Remark,
                    Children = list
                };
                return View(roles);
            }
        }

        [HttpGet]
        public IActionResult Query(string id)
        {
            var roles = new RoleMenuDto();
            if (id.IsEmpty())
            {
                return View(roles);
            }
            else
            {
                var role = _roleServices.QueryableToEntity(c => c.RoleId == SqlFunc.ToInt64(id));
                var list = _rolemenuServices.QueryableToList(c => c.RoleId == SqlFunc.ToInt64(id));
                roles = new RoleMenuDto()
                {
                    RoleId = role?.RoleId.ToString(),
                    RoleName = role?.RoleName,
                    RoleType = role?.RoleType,
                    Remark = role?.Remark,
                    Children = list
                };
                return View(roles);
            }
        }

        [HttpPost]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Sys_role role, [FromForm]string id, [FromForm]string[] menuId)
        {
            //int[] menuIds = Array.ConvertAll(menuId, new Converter<string, int>(c => c.ToInt32()));
            //Array.Sort(menuIds);
            //var arrs = (from d in menuId orderby d.ToInt32() ascending select d.ToInt32()).ToArray();
            //var arrs2 = (from d in arrs select d).ToArray();

            var validator = new SysRoleFluent();
            ValidationResult results = validator.Validate(role);
            bool success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (_roleServices.IsAny(c => c.RoleName == role.RoleName))
                {
                    return BootJsonH((false, PubConst.Role2));
                }
                var flag = _roleServices.Insert(role, UserDtoCache.UserId, menuId);
                return BootJsonH(flag.IsSuccess ? (flag.IsSuccess, PubConst.Add1) : (flag.IsSuccess, PubConst.Add2));
            }
            else
            {
                //admin
                //var model = _roleServices.QueryableToEntity(c => c.RoleId == SqlFunc.ToInt64(id));
                //if (model.RoleType == "admin")
                //{
                //    return BootJsonH((false, PubConst.Role1));
                //}
                role.RoleId = id.ToInt64();
                var flag = _roleServices.Update(role, UserDtoCache.UserId, menuId);
                return BootJsonH(flag.IsSuccess ? (flag.IsSuccess, PubConst.Update1) : (flag.IsSuccess, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            var model = _roleServices.QueryableToEntity(c => c.RoleId == SqlFunc.ToInt64(id));
            if (model.RoleType == "admin")
            {
                return BootJsonH((false, PubConst.Role1));
            }
            var user = _userServices.IsAny(c => c.RoleId == SqlFunc.ToInt64(id));
            if (user)
            {
                return BootJsonH((false, PubConst.Role3));
            }
            var flag = _roleServices.Update(new Sys_role { RoleId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
            if (flag)
            {
                _rolemenuServices.Delete(c => c.RoleId == SqlFunc.ToInt64(id));
                return BootJsonH((flag, PubConst.Delete1));
            }
            else
            {
                return BootJsonH((flag, PubConst.Delete2));
            }
        }
    }
}