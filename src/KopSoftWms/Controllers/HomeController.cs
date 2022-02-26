using IServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Diagnostics;
using System.Text;
using YL.Core.Dto;
using YL.Models;
using YL.NetCore.Attributes;
using YL.NetCore.NetCoreApp;

namespace KopSoftWms.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISys_userServices _userServices;
        private readonly ISys_logServices _logServices;
        private readonly ISys_roleServices _roleServices;
        private readonly IMemoryCache _cache;
        private readonly IMediator _mediator;
        //private readonly Func<string, SqlSugarClient> _serviceAccessor;

        public HomeController(ISys_logServices logServices,
            ISys_userServices sysUserServices,
            ISys_roleServices roleServices, IMemoryCache cache, IMediator mediator
            )
        {
            _logServices = logServices;
            _userServices = sysUserServices;
            _roleServices = roleServices;
            _cache = cache;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            ViewBag.title = GetDescriptor("title");
            ViewBag.keywords = GetDescriptor("keywords");
            ViewBag.description = GetDescriptor("description");
            ViewBag.company = GetDescriptor("company");
            ViewBag.nickname = UserDtoCache.UserNickname;
            ViewBag.headimg = UserDtoCache.HeadImg;

            //菜单
            var menus = _roleServices.GetMenu(UserDtoCache.RoleId.Value);
            GetMemoryCache.Set("menu_" + UserDtoCache.UserId, menus);
            ViewData["menu"] = menus;
            return View();
        }

        [AddHeader("Content-Type", YL.Utils.Files.ContentType.ContentTypeSSE)]
        [AddHeader("Cache-Control", YL.Utils.Files.ContentType.CacheControl)]
        [AddHeader("Connection", YL.Utils.Files.ContentType.Connection)]
        public IActionResult ServerSendMsg()
        {
            var a = new ServerSentEventsDto
            {
                Data = DateTime.Now.ToString(),
                Event = "message",
                Id = Guid.NewGuid().ToString(),
                Retry = "3000",
            };
            StringBuilder sb = new StringBuilder();
            sb.Append($"id:{a.Id}\n");
            sb.Append($"retry:{a.Retry}\n");
            sb.Append($"event:{a.Event}\n");
            sb.Append($"data:{a.Data}\n\n");
            return Content(sb.ToString());
        }

        public IActionResult Welcome()
        {
            //ViewBag.keywords = GetDescriptor("keywords");
            ViewBag.title = GetDescriptor("title");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}