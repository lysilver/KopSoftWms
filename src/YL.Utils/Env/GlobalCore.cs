﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using YL.Utils.Extensions;

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

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetRequiredService<T>()
        {
            using (var scope = _app.ApplicationServices.GetRequiredService<IServiceProvider>().CreateScope())
            {
                return scope.ServiceProvider.GetRequiredService<T>();
            }
        }

        public static IWebHostEnvironment GetHostingEnvironment => GetRequiredService<IWebHostEnvironment>();

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
            ip = ip.Replace("::ffff:", "");
            return ip == "::1" ? "127.0.0.1" : ip;
        }

        public static string GetUrl()
        {
            var req = Current.Request;
            return $"{req.Scheme}://{req.Host}{req.PathBase}{req.Path}{req.QueryString}";
        }

        public static IEnumerable<Claim> GetClaim()
        {
            var isAuthenticated = Current.User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                return Current.User.Claims;
            }
            else
            {
                return null;
            }
        }

        public static string GetBrowser() => Current.Request.Headers.UserAgent.ToString();

        public static string GetHeaders(string key) => Current.Request.Headers[key].ToString();
    }
}