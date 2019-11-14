using IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
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
using YL.Utils.Json;
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

            ViewBag.keywords = GetDescriptor("keywords");
            ViewBag.description = GetDescriptor("description");
            ViewBag.customer = GetDescriptor("customer");
            ViewBag.company = GetDescriptor("company");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CheckLoginAsync([FromBody]SysUserDto sys)
        {
            ClearCache(MenuKey);
            ClearCache(UserKey);
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
                sys.UserId = item.Item3.UserId;
                sys.UserName = item.Item3.UserName;
                sys.UserNickname = item.Item3.UserNickname;
                sys.RoleId = item.Item3.RoleId;
                sys.HeadImg = item.Item3.HeadImg;
                GetMemoryCache.Set("user_" + item.Item3.UserId, sys);
                _userServices.Login(item.Item3.UserId, GetIp());
                await _mediator.Publish(new Sys_log
                {
                    LogId = PubId.SnowflakeId,
                    Browser = GetBrowser(),
                    CreateBy = sys.UserId,
                    Description = $"{sys.UserNickname}登录成功",
                    LogIp = GetIp(),
                    Url = GetUrl(),
                    LogType = LogType.login.EnumToString(),
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
            }
            item.Item3 = null;
            //return Json(item);
            return Content(item.ToJsonL());
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            ClearCache(MenuKey);
            ClearCache(UserKey);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}