using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Claims;
using YL.Core.Dto;
using YL.Utils.Extensions;
using YL.Utils.Json;
using YL.Utils.Table;
using YL.Utils.Pub;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;

namespace YL.NetCore.NetCoreApp
{
    /// <summary>
    ///[FromBody] 请求正文 只能有一个参数 json 针对复杂类型参数进行推断
    ///[FromForm] 请求正文中的表单数据
    ///[FromHeader] 请求标头
    ///[FromQuery]     请求查询字符串参数
    ///[FromRoute] 当前请求中的路由数据
    ///[FromServices]  作为操作参数插入的请求服务
    /// url:https://docs.microsoft.com/zh-cn/aspnet/core/web-api/?view=aspnetcore-2.1
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
        private IMemoryCache _memory;
        private IConfiguration _configuration;
        public string AppRoot { get { return CreateService<IHostingEnvironment>().ContentRootPath; } }

        public string WebRoot { get { return CreateService<IHostingEnvironment>().WebRootPath; } }

        protected IMemoryCache GetMemoryCache
        {
            get
            {
                if (_memory == null)
                {
                    _memory = CreateService<IMemoryCache>();
                    return _memory;
                }
                return _memory;
            }
        }

        public List<string> GetCacheKeys()
        {
            var flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var entries = GetMemoryCache.GetType().GetField("_entries", flags).GetValue(GetMemoryCache);
            var keys = new List<string>();
            if (!(entries is IDictionary cacheItems)) return keys;
            foreach (DictionaryEntry cacheItem in cacheItems)
            {
                keys.Add(cacheItem.Key.ToString());
            }
            return keys;
        }

        protected IConfiguration GetConfiguration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = CreateService<IConfiguration>();
                    return _configuration;
                }
                return _configuration;
            }
        }

        //IMemoryCache
        protected SysUserDto UserDto
        {
            get
            {
                var isAuthenticated = HttpContext.User.Identity.IsAuthenticated;
                if (isAuthenticated)
                {
                    var claims = User.Claims;
                    var sys = new SysUserDto
                    {
                        UserId = claims.SingleOrDefault(c => c.Type == ClaimTypes.Sid).Value.ToInt64(),
                        UserName = claims.SingleOrDefault(c => c.Type == ClaimTypes.Surname).Value,
                        UserNickname = claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value,
                        RoleId = claims.SingleOrDefault(c => c.Type == ClaimTypes.Role).Value.ToInt64(),
                        HeadImg = claims.SingleOrDefault(c => c.Type == ClaimTypes.Uri).Value
                    };
                    return sys;
                }
                else
                {
                    return null;
                }
            }
        }

        protected SysUserDto UserDtoCache
        {
            get
            {
                GetMemoryCache.TryGetValue("user_" + UserDto?.UserId, out SysUserDto sys);
                return sys ?? UserDto;
            }
        }

        protected string MenuKey
        {
            get
            {
                return "menu_" + UserDtoCache?.UserId;
            }
        }

        protected string UserKey
        {
            get
            {
                return "user_" + UserDtoCache?.UserId;
            }
        }

        protected virtual void ClearCache(string key)
        {
            //var _cache = CreateService<IMemoryCache>();
            //_cache.Remove(key);
            GetMemoryCache.Remove(key);
        }

        protected virtual void ClearAllCache()
        {
            foreach (var key in GetCacheKeys())
            {
                GetMemoryCache.Remove(key);
            }
        }

        protected IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        protected JsonResult BootJson(object data, int total)
        {
            return Json(Bootstrap.GridData(data, total));
        }

        protected JsonResult BootJson((object, int) data)
        {
            return Json(Bootstrap.GridData(data.Item1, data.Item2));
        }

        protected ContentResult BootJsonH(object obj)
        {
            //var str = obj.JilToJson();
            var str = obj.ToJsonL();
            return Content(str);
        }

        protected ContentResult BootJsonH((bool, object) data)
        {
            //var str = data.JilToJson();
            var str = data.ToJsonL();
            return Content(str);
        }

        protected string JsonL((bool, object) data)
        {
            var str = data.ToJsonL();
            return str;
        }

        protected ContentResult BootJsonH((int, object) data)
        {
            //var str = data.JilToJson();
            var str = data.ToJsonL();
            return Content(str);
        }

        protected ContentResult BootJsonH((object, int) data)
        {
            //var str = Bootstrap.GridData(data.Item1, data.Item2).JilToJson();
            var str = Bootstrap.GridData(data.Item1, data.Item2).ToJsonL();
            return Content(str);
        }

        protected virtual T CreateService<T>()
        {
            return (T)HttpContext.RequestServices.GetService(typeof(T));
        }

        protected virtual string GetDescriptor(string key)
        {
            return ControllerContext.ActionDescriptor.Properties[key].ToString();
        }

        protected virtual object GetDescriptorObj(string key)
        {
            return ControllerContext.ActionDescriptor.Properties[key];
        }

        protected virtual string GetIp()
        {
            var ip = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (ip.IsEmpty())
            {
                ip = HttpContext.Connection.RemoteIpAddress.ToString();
            }
            ip = ip.Replace("::ffff:", "");
            return ip == "::1" ? "127.0.0.1" : ip;
        }

        protected virtual string GetUrl()
        {
            var req = HttpContext.Request;
            return $"{req.Scheme}://{req.Host}{req.PathBase}{req.Path}{req.QueryString}";
        }

        protected virtual string GetBrowser()
        {
            return HttpContext.Request.Headers["User-Agent"].ToString();
        }

        protected virtual string GetRequestHeaders(string key)
        {
            return HttpContext.Request.Headers[key].ToString();
        }

        protected virtual void SetResponseHeader(string key, string value)
        {
            HttpContext.Response.Headers.Add(key, value);
        }
    }
}