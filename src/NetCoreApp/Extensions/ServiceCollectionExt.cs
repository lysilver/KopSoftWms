using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using YL.Utils.Check;
using YL.Utils.Extensions;
using YL.Utils.Log;
using YL.Utils.Security;
using YL.Utils.Json;
using System;

namespace YL.NetCoreApp.Extensions
{
    /// <summary>
    /// ServiceCollection
    /// </summary>
    public static class ServiceCollectionExt
    {
        /// <summary>
        /// HttpContext上下文
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddHttpContext(this IServiceCollection services)
        {
            //services.AddHttpContextAccessor();
            return services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static IServiceCollection AddHttpClientFactory(this IServiceCollection services)
        {
            //IHttpClientFactory HttpClientFactory
            return services.AddHttpClient();
        }

        public static IServiceCollection AddContextAccessor(this IServiceCollection services)
        {
            if (services.Count(x => x.ServiceType == typeof(IHttpContextAccessor)) == 0)
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            if (services.Count(x => x.ServiceType == typeof(IActionContextAccessor)) == 0)
                services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            return services;
        }

        public static IServiceCollection AddContextFactory(this IServiceCollection services)
        {
            return services.AddSingleton<IHttpContextFactory, HttpContextFactory>();
        }

        /// <summary>
        /// url小写
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddLowercaseUrls(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
            return services;
        }

        public static IServiceCollection AddUrlHelper(this IServiceCollection services)
        {
            services
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                .AddScoped(it =>
                    it
                        .GetRequiredService<IUrlHelperFactory>()
                        .GetUrlHelper(it.GetRequiredService<IActionContextAccessor>().ActionContext));
            return services;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfigurationRoot configuration)
        {
            return services.AddSingleton(configuration);
        }

        /// <summary>
        /// 中文乱码
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddHtmlEncoder(this IServiceCollection services)
        {
            return services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
        }

        public static IServiceCollection AddXss(this IServiceCollection services)
        {
            return services.AddSingleton(typeof(Xss));
        }

        /// <summary>
        /// Nlog
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddNlog(this IServiceCollection services)
        {
            return services.AddSingleton<ILogUtil, NlogUtil>();
        }

        /// <summary>
        ///Br
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBr(this IServiceCollection services)
        {
            return services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });
        }

        /// <summary>
        /// Gzip
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddGzip(this IServiceCollection services)
        {
            return services.AddResponseCompression(options =>
             {
                 options.Providers.Add<GzipCompressionProvider>();
                 options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                 {
                     // Default
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                    // Custom
                    "image/svg+xml",
                    "font/woff2",
                    "application/font-woff",
                    "application/font-ttf",
                    "application/font-eot",
                    "image/jpeg",
                    "image/png"
                 });
             }).Configure<GzipCompressionProviderOptions>(options =>
             {
                 options.Level = CompressionLevel.Fastest;
             });
        }

        public static IServiceCollection AddXsrf(this IServiceCollection services)
        {
            return services.AddAntiforgery(options =>
            {
                //X-CSRF-TOKEN
                options.HeaderName = "X-XSRF-TOKEN";
            });
        }

        public static IServiceCollection AddOption<T>(this IServiceCollection services, string key, IConfiguration configuration) where T : class, new()
        {
            //if (key.IsEmpty())
            //{
            //    throw new ArgumentNullException(nameof(key));
            //}
            CheckNull.ArgumentIsNullException(key, nameof(key));
            return services.AddOptions().Configure<T>(configuration?.GetSection(key));
        }

        /// <summary>
        /// 上传大小限制
        /// </summary>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddMultipartBodyLengthLimit(this IServiceCollection services, IConfiguration configuration, string key = null)
        {
            if (key.IsEmpty())
            {
                //throw new ArgumentNullException(nameof(key));
                services.Configure<FormOptions>(
                f =>
                {
                    f.ValueLengthLimit = int.MaxValue;
                    f.MultipartBodyLengthLimit = int.MaxValue;
                }
                );
            }
            else
            {
                services.Configure<FormOptions>(
               f =>
               {
                   f.ValueLengthLimit = configuration[key].ToInt32();
                   f.MultipartBodyLengthLimit = configuration[key].ToInt32();
               }
               );
            }
            return services;
        }

        /// <summary>
        /// 数据保护
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataProtectionL(this IServiceCollection services)
        {
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory()));
            return services;
        }

        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = configuration["Redis"];
                options.InstanceName = "SampleInstance";
            });
            return services;
        }

        /// <summary>
        /// 依赖 app.UseGlobalCore();
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configAction"></param>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        public static IServiceCollection AddJson(this IServiceCollection services, Action<JsonConfig> configAction, ServiceLifetime lifetime = ServiceLifetime.Singleton)
        {
            var config = new JsonConfig();
            configAction?.Invoke(config);
            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(config);
                    break;

                case ServiceLifetime.Scoped:
                    services.AddScoped(serviceProvider =>
                    {
                        return config;
                    });
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(serviceProvider =>
                    {
                        return config;
                    });
                    break;

                default:
                    services.AddSingleton(config);
                    break;
            }

            return services;
        }

        public static IServiceCollection AddLazy(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    return services.AddSingleton(typeof(Lazy<>));

                case ServiceLifetime.Scoped:
                    return services.AddScoped(typeof(Lazy<>));

                case ServiceLifetime.Transient:
                    return services.AddTransient(typeof(Lazy<>));

                default:
                    return services.AddTransient(typeof(Lazy<>));
            }
        }
    }
}