using IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using YL.Core.Dto;
using YL.Core.Entity;
using YL.NetCore.NetCoreApp;
using YL.Utils.Extensions;
using YL.Utils.Pub;
using YL.Utils.Security;
using MediatR;

namespace KopSoftWms.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ISys_userServices _userServices;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ISys_logServices _logServices;
        private readonly IConfiguration _configuration;
        private readonly Xss _xss;
        private readonly IMediator _mediator;

        public LoginController(Xss xss, ISys_logServices logServices, IHttpContextAccessor httpContext, IConfiguration configuration, ISys_userServices sys_User, IMediator mediator)
        {
            _httpContext = httpContext;
            _configuration = configuration;
            _userServices = sys_User;
            _logServices = logServices;
            _xss = xss;
            _mediator = mediator;
        }

        //string returnUrl = null
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            //TempData["returnUrl"] = returnUrl;
            ViewBag.title = GetDescriptor("title");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CheckLoginAsync([FromBody]SysUserDto sys)
        {
            ClearCache("user");
            ClearCache("menu");
            var item = _userServices.CheckLogin(sys);
            if (item.Item1)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var claims = new List<Claim>
                  {
                      new Claim(ClaimTypes.Name, item.Item3.UserName),
                      new Claim(ClaimTypes.Sid,item.Item3.UserId.ToString()),
                      new Claim(ClaimTypes.Surname,item.Item3.UserNickname),
                      new Claim(ClaimTypes.Role,item.Item3.RoleId?.ToString()),
                      new Claim(ClaimTypes.Uri,string.IsNullOrWhiteSpace(item.Item3.HeadImg)?Path.Combine("upload","head","4523c812eb2047c39ad91f8c5de3fb31.jpg"):item.Item3.HeadImg)
                  };
                var claimsIdentitys = new ClaimsIdentity(
               claims,
               CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentitys);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                {
                    IssuedUtc = DateTime.Now,
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(1),
                });
            }
            else
            {
                await _mediator.Publish(new Sys_log
                {
                    LogId = PubId.SnowflakeId,
                    Browser = GetBrowser(),
                    Description = $"{_xss.Filter(sys.UserNickname)}登录失败",
                    LogIp = GetIp(),
                    Url = GetUrl(),
                    LogType = LogType.login.EnumToString()
                });
                //_logServices.Insert(new Sys_log
                //{
                //    LogId = PubId.SnowflakeId,
                //    Browser = GetBrowser(),
                //    Description = $"{_xss.Filter(sys.UserNickname)}登录失败",
                //    LogIp = GetIp(),
                //    Url = GetUrl(),
                //    LogType = LogType.login.EnumToString()
                //});
            }
            item.Item3 = null;
            return Json(item);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            ClearCache("menu"); //清除菜单
            ClearCache("user");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}