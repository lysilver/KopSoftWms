using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using YL.Utils.Extensions;
using YL.Utils.Pub;

namespace YL.Utils.Env
{
    /// <summary>
    /// 使用方法app.UseGlobalCore();
    /// </summary>
    public class GlobalCore
    {
        private static IApplicationBuilder _app;

        public static void Configure(IApplicationBuilder app)
        {
            _app = app ?? throw new ArgumentNullException(nameof(app));
        }

        public static T GetRequiredService<T>() => _app.ApplicationServices.GetRequiredService<T>();

        public static IServiceProvider GetServiceProvider => GetRequiredService<IServiceProvider>();

        public static IHostingEnvironment GetHostingEnvironment => GetRequiredService<IHostingEnvironment>();

        public static HttpContext Current => GetRequiredService<IHttpContextAccessor>().HttpContext;

        public static IConfiguration DIConfig => GetRequiredService<IConfiguration>();

        public static IMemoryCache Cache => GetRequiredService<IMemoryCache>();

        public static string WebRootPath => GetHostingEnvironment?.WebRootPath;

        public static string ContentRootPath => GetHostingEnvironment?.ContentRootPath;

        public static string EnvironmentName => GetHostingEnvironment?.EnvironmentName;

        public static string ApplicationName => GetHostingEnvironment?.ApplicationName;

        public static string GetIp()
        {
            var ip = Current.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (ip.IsEmpty())
            {
                ip = Current.Connection.RemoteIpAddress.ToString();
            }
            if (PubSys.IsLinux())
            {
                return ip.Replace("::ffff:", "");
            }
            return ip == "::1" ? "127.0.0.1" : ip;
        }

        public static string GetUrl()
        {
            var req = Current.Request;
            return $"{req.Scheme}://{req.Host}{req.PathBase}{req.Path}{req.QueryString}";
        }

        public static string GetBrowser() => Current.Request.Headers["User-Agent"].ToString();

        public static string GetHeaders(string key) => Current.Request.Headers[key].ToString();
    }
}