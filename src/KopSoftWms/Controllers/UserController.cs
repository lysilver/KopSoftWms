using FluentValidation.Results;
using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.IO;
using System.Linq;
using YL.Core.Entity;
using YL.Core.Entity.Fluent.Validation;
using YL.NetCore.Attributes;
using YL.NetCore.NetCoreApp;
using YL.Utils.Delegate;
using YL.Utils.Extensions;
using YL.Utils.Pub;
using YL.Utils.Security;
using YL.Utils.Table;

namespace KopSoftWms.Controllers
{
    public class UserController : BaseController
    {
        private readonly ISys_userServices _userServices;
        private readonly ISys_deptServices _deptServices;
        private readonly ISys_roleServices _roleServices;

        public UserController(ISys_roleServices roleServices, ISys_deptServices deptServices, ISys_userServices userServices)
        {
            _roleServices = roleServices;
            _deptServices = deptServices;
            _userServices = userServices;
        }

        [HttpGet]
        [CheckMenu]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [OperationLog(LogType.select)]
        public ContentResult List([FromForm]Bootstrap.BootstrapParams bootstrap)
        {
            //单表
            //var express = ExpressionExt.Init<Sys_user>();
            //express.And(c => c.IsDel == 1);
            //var order = ExpressionExt.InitO<Sys_user>(bootstrap.sort);
            //if (!bootstrap.search.IsEmpty())
            //{
            //    express.And(c => c.UserName == bootstrap.search && c.UserNickname == bootstrap.search);
            //}
            //var list = _userServices.QueryableToPage(express, order, bootstrap.order, bootstrap.offset, bootstrap.limit);

            var sd = _userServices.PageList(bootstrap);
            return Content(sd);
        }

        public IActionResult Add(string id)
        {
            ViewBag.Dept = _deptServices.QueryableToList(c => c.IsDel == 1);
            ViewBag.Role = _roleServices.QueryableToList(c => c.IsDel == 1);
            var user = new Sys_user();
            if (id.IsEmpty())
            {
                return View(user);
            }
            else
            {
                user = _userServices.QueryableToEntity(c => c.UserId == SqlFunc.ToInt64(id));
                return View(user);
            }
        }

        public IActionResult Info()
        {
            var user = _userServices.QueryableToEntity(c => c.UserId == SqlFunc.ToInt64(UserDtoCache.UserId));
            return View(user);
        }

        public IActionResult UploadHeadImg(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BootJsonH((false, PubConst.File1));
            }
            string fileExt = Path.GetExtension(file.FileName).ToLower();
            var img = Path.Combine("upload", "head", PubId.GetUuid()) + fileExt;
            var filepath = Path.Combine(WebRoot, img);
            return DelegateUtil.TryExecute<IActionResult>(() =>
            {
                using (var stream = new FileStream(filepath, FileMode.CreateNew))
                {
                    file.CopyTo(stream);
                }
                var flag = _userServices.Update(new Sys_user { UserId = SqlFunc.ToInt64(UserDtoCache.UserId), HeadImg = img, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.HeadImg, c.ModifiedBy, c.ModifiedDate });
                return BootJsonH(flag ? (flag, PubConst.File6) : (flag, PubConst.File7));
            }, BootJsonH((false, PubConst.File5))
             );
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult UpdatePwd()
        {
            var user = _userServices.QueryableToEntity(c => c.UserId == SqlFunc.ToInt64(UserDtoCache.UserId));
            return View(user);
        }

        [HttpPost]
        [OperationLog(LogType.update)]
        public IActionResult UpdatePwd([FromForm]Sys_user sys_User, [FromForm]string id)
        {
            //用Sys_user中的Sort接收旧密码
            if (id.IsEmptyZero())
            {
                return BootJsonH((false, PubConst.User2));
            }
            else
            {
                var user = _userServices.QueryableToEntity(c => c.UserId == SqlFunc.ToInt64(id));
                if (sys_User.Sort.ToMd5() != user.Pwd)
                {
                    return BootJsonH((false, PubConst.User4));
                }
                user.Pwd = sys_User.Pwd.ToMd5();
                user.ModifiedBy = UserDtoCache.UserId;
                user.ModifiedDate = DateTimeExt.DateTime;
                bool flag = _userServices.Update(user);
                return BootJsonH(flag ? (flag, PubConst.Update3) : (flag, PubConst.Update4));
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Sys_user sys_User, [FromForm]string id)
        {
            var validator = new SysUserFluent();
            ValidationResult results = validator.Validate(sys_User);
            bool success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (_userServices.IsAny(c => c.UserNickname == sys_User.UserNickname))
                {
                    return BootJsonH((false, PubConst.User1));
                }
                sys_User.UserId = PubId.SnowflakeId;
                sys_User.Pwd = sys_User.Pwd.ToMd5();
                sys_User.CreateBy = UserDtoCache.UserId;
                sys_User.LoginTime = 0;
                sys_User.HeadImg = Path.Combine("upload", "head", "4523c812eb2047c39ad91f8c5de3fb31.jpg");
                bool flag = _userServices.Insert(sys_User);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                sys_User.UserId = id.ToInt64();
                sys_User.ModifiedBy = UserDtoCache.UserId;
                sys_User.ModifiedDate = DateTimeExt.DateTime;
                bool flag = _userServices.Update(sys_User);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            var flag = _userServices.Update(new Sys_user { UserId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
            return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
        }

        [HttpGet]
        [OperationLog(LogType.update)]
        public IActionResult Enable(string id, string type)
        {
            if (type == "1")
            {
                //禁用
                var flag = _userServices.Update(new Sys_user { UserId = SqlFunc.ToInt64(id), IsEabled = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsEabled, c.ModifiedBy, c.ModifiedDate });
                return BootJsonH(flag ? (flag, PubConst.Enable3) : (flag, PubConst.Enable4));
            }
            else
            {
                //启用
                var flag = _userServices.Update(new Sys_user { UserId = SqlFunc.ToInt64(id), IsEabled = 1, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsEabled, c.ModifiedBy, c.ModifiedDate });
                return BootJsonH(flag ? (flag, PubConst.Enable1) : (flag, PubConst.Enable2));
            }
        }
    }
}