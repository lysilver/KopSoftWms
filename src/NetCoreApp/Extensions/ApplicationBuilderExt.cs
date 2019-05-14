using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using YL.NetCore.Middlewares;
using YL.Utils.Env;
using YL.Utils.Extensions;
using YL.Utils.Http;

namespace YL.NetCoreApp.Extensions
{
    public static class ApplicationBuilderExt
    {
        /// <summary>
        /// 启用全局静态化
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGlobalCore(this IApplicationBuilder app)
        {
            GlobalCore.Configure(app);
            return app;
        }

        /// <summary>
        /// 提供 Web 根目录外的文件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="secends"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseDirectoryBrowserL(this IApplicationBuilder app, string fileName)
        {
            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), $@"{fileName}")),
                RequestPath = new PathString($"/{fileName}"),
            });
            return app;
        }

        /// <summary>
        /// 启用目录浏览
        /// </summary>
        /// <param name="app"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseFile(this IApplicationBuilder app, string fileName)
        {
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), $@"{fileName}")),
                RequestPath = new PathString($"/{fileName}"),
                EnableDirectoryBrowsing = true
            });
            return app;
        }

        /// <summary>
        /// 添加支持less
        /// img js css 设置 HTTP 响应标头
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCacheControl(this IApplicationBuilder app, int secends = 600)
        {
            var provider = new FileExtensionContentTypeProvider();
            var providers = provider.Mappings;
            //provider.Mappings[".less"] = "text/css";
            providers.Add(".less", "text/css");
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public,max-age={secends}");
                },
                ContentTypeProvider = provider,
            });
            return app;
        }

        public static IApplicationBuilder UseCacheControlHtml(this IApplicationBuilder app, int secends = 10)
        {
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(secends)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };
                await next();
            });
            return app;
        }

        public static IApplicationBuilder UseXssProtection(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1"); //启用XSS保护，并在检测到任何XSS漏洞的情况下阻止加载页面。
                await next();
            });
            return app;
        }

        public static IApplicationBuilder UseExecuteTime(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExecuteTimeMiddleware>();
        }

        public static IApplicationBuilder UseException(this IApplicationBuilder app)
        {
            return app.UseExceptionHandler((err) =>
           {
               err.Run(async context =>
               {
                   var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                   var exception = errorFeature.Error;
                   var problemDetails = new ProblemDetails
                   {
                       Instance = $"urn:myorganization:error:{Guid.NewGuid()}"
                   };
                   if (exception is BadHttpRequestException badHttpRequestException)
                   {
                       problemDetails.Title = "Invalid request";
                       problemDetails.Status = (int)typeof(BadHttpRequestException).GetProperty("StatusCode",
                           BindingFlags.NonPublic | BindingFlags.Instance).GetValue(badHttpRequestException);
                       problemDetails.Detail = badHttpRequestException.Message;
                   }
                   else
                   {
                       problemDetails.Title = "An unexpected error occurred!";
                       problemDetails.Status = 500;
                       problemDetails.Detail = exception.ExceptionToString();
                   }
                   await Task.Factory.StartNew(() =>
                   {
                       context.Response.StatusCode = problemDetails.Status.Value;
                       context.Response.WriteJson(problemDetails, "application/problem+json");
                   });
               });
           });
        }
    }
}