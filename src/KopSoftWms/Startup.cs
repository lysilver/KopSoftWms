using IRepository;
using IServices;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Services;
using SqlSugar;
using System.Text;
using YL.Core.Orm.SqlSugar;
using YL.NetCore.Attributes;
using YL.NetCore.Conventions;
using YL.NetCore.DI;
using YL.NetCoreApp.Extensions;
using YL.Utils.Json;
using YL.Utils.Pub;

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
                option.Conventions.Add(new ApplicationDescription("keywords", Configuration["sys:keywords"]));
                option.Conventions.Add(new ApplicationDescription("description", Configuration["sys:description"]));
                option.Conventions.Add(new ApplicationDescription("customer", Configuration["sys:customer"]));
                option.Conventions.Add(new ApplicationDescription("company", Configuration["sys:company"]));
                option.Conventions.Add(new ApplicationDescription("product", Configuration["sys:product"]));
            });
            services.AddControllersWithViews();
            services.AddRazorPages()
                    .AddRazorRuntimeCompilation();
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            PubId.InitId();
            services.AddTimedJob();
            services.AddOptions();
            services.AddXsrf();
            services.AddXss();
            services.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                c.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(cfg =>
            {
                cfg.LoginPath = "/Login/Index";
                cfg.LogoutPath = "/Login/Logout";
                //cfg.ExpireTimeSpan = TimeSpan.FromDays(1);
                //cfg.Cookie.Expiration = TimeSpan.FromDays(1);
                cfg.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.Cookie.Path = "/";
                cfg.Cookie.HttpOnly = true;
                //cfg.SlidingExpiration = true;
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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.AddBr(); //br压缩
            services.AddResponseCompression();//添加压缩
            services.AddResponseCaching(); //响应式缓存
            services.AddMemoryCache();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            //@1 DependencyInjection 注册
            services.AddNlog(); //添加Nlog
            RegisterBase(services);
            ServiceExtension.RegisterAssembly(services, "Services");
            ServiceExtension.RegisterAssembly(services, "Repository");
            SetServiceResolve(services);
        }

        private static void SetServiceResolve(IServiceCollection services)
        {
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles(); //使用静态文件

            app.UseGlobalCore();
            app.UseExecuteTime();
            app.UseTimedJob();
            app.UseResponseCompression();  //使用压缩
            app.UseResponseCaching();    //使用缓存

            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "areas",
                    areaName: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}