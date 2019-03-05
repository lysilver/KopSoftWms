using IRepository;
using IServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;
using SqlSugar;
using System;
using YL.Core.Orm.SqlSugar;
using YL.NetCore.Attributes;
using YL.NetCore.Conventions;
using YL.NetCore.DI;
using YL.NetCoreApp.Extensions;
using YL.Utils.Json;

namespace YL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //IServiceProvider This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option =>
            {
                option.Filters.Add<BaseExceptionAttribute>();
                //option.Filters.Add<FilterXSSAttribute>();
                option.Conventions.Add(new ApplicationDescription("title", Configuration["sys:title"]));
                option.Conventions.Add(new ApplicationDescription("company", Configuration["sys:company"]));
                option.Conventions.Add(new ApplicationDescription("customer", Configuration["sys:customer"]));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            services.AddTimedJob();
            services.AddOptions();
            services.AddXsrf();
            services.AddXss();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, cfg =>
            {
                cfg.LoginPath = "/Login/Index";
                cfg.ExpireTimeSpan = TimeSpan.FromDays(1);
                cfg.Cookie.Expiration = TimeSpan.FromDays(1);
                cfg.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.Cookie.Path = "/";
                cfg.Cookie.HttpOnly = true;
                cfg.SlidingExpiration = true;
            });
            var sqlSugarConfig = SqlSugarConfig.GetConnectionString(Configuration);
            services.AddSqlSugarClient<SqlSugarClient>(config =>
            {
                config.ConnectionString = sqlSugarConfig.Item2;
                config.DbType = sqlSugarConfig.Item1;
                config.IsAutoCloseConnection = true;
                config.InitKeyType = InitKeyType.Attribute;
                //config.IsShardSameThread = true;
            });
            services.AddJson(o =>
            {
                o.JsonType = JsonType.Jil;
            });
            services.AddHttpContextAccessor();
            services.AddHtmlEncoder();
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.AddBr(); //br压缩
            services.AddResponseCompression();//添加压缩
            services.AddResponseCaching(); //响应式缓存
            services.AddMemoryCache();

            //@1 DependencyInjection 注册
            services.AddNlog(); //添加Nlog
            RegisterBase(services);
            ServiceExtension.RegisterAssembly(services, "Services");
            ServiceExtension.RegisterAssembly(services, "Repository");
            var bulid = services.BuildServiceProvider();
            ServiceResolve.SetServiceResolve(bulid);
        }

        /// <summary>
        /// 泛型注册
        /// </summary>
        /// <param name="services"></param>
        /// <param name="injection"></param>
        private static void RegisterBase(IServiceCollection services, ServiceLifetime injection = ServiceLifetime.Scoped)
        {
            switch (injection)
            {
                case ServiceLifetime.Scoped:
                    services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                    services.AddScoped(typeof(IBaseServices<>), typeof(BaseServices<>));
                    break;

                case ServiceLifetime.Singleton:
                    services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                    services.AddSingleton(typeof(IBaseServices<>), typeof(BaseServices<>));
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                    services.AddTransient(typeof(IBaseServices<>), typeof(BaseServices<>));
                    break;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseGlobalCore();
            app.UseExecuteTime();
            app.UseTimedJob();
            app.UseResponseCompression();  //使用压缩
            app.UseResponseCaching();    //使用缓存
            app.UseAuthentication();
            app.UseStaticFiles(); //使用静态文件
            app.UseCookiePolicy();
            app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
                // Areas
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );
            });
        }
    }
}