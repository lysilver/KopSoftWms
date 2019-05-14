using IRepository;
using IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using SqlSugar;
using System;
using YL.NetCore.DI;
using YL.NetCoreApp.Extensions;
using YL.Core.Orm.SqlSugar;
using Services;
using YL.Utils.Configs;
using YL.Utils.Table;
using Microsoft.AspNetCore.Builder.Internal;
using YL.Utils.Json;
using MediatR;

namespace XUnitTestKopSoftWms
{
    public class BaseControllerTest
    {
        public IServiceCollection serviceDescriptors;
        public IServiceProvider ServiceProvider => GetServices();

        public virtual IServiceProvider GetServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(new ConfigurationBuilder().Build());
            var Configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddJson(o =>
            {
                o.JsonType = JsonType.Jil;
            });
            services.AddDIProperty();
            services.AddOptions();
            services.AddXsrf();
            services.AddXss();
            var config2 = ConfigUtil.GetJsonConfig();
            var sqlSugarConfig = SqlSugarConfig.GetConnectionString(config2);
            services.AddSqlSugarClient<SqlSugarClient>(config =>
            {
                config.ConnectionString = sqlSugarConfig.Item2;
                config.DbType = sqlSugarConfig.Item1;
                config.IsAutoCloseConnection = true;
                config.InitKeyType = InitKeyType.Attribute;
                //config.IsShardSameThread = true;
            });
            services.AddHttpContextAccessor();
            services.AddHtmlEncoder();
            services.AddBr(); //br压缩
            services.AddResponseCompression();//添加压缩
            services.AddMemoryCache();
            services.AddMediatR(typeof(BaseControllerTest).GetTypeInfo().Assembly);

            services.AddNlog(); //添加Nlog
            services.AddLogging();
            RegisterBase(services);
            ServiceExtension.RegisterAssembly(services, "Services");
            ServiceExtension.RegisterAssembly(services, "Repository");
            serviceDescriptors = services;
            services.AddSingleton<IApplicationBuilder>(new ApplicationBuilder(services.BuildServiceProvider()));
            var app = services.BuildServiceProvider().GetService<IApplicationBuilder>();
            app.UseGlobalCore();
            return services.BuildServiceProvider();
        }

        public virtual Bootstrap.BootstrapParams GetBootstrap
        {
            get
            {
                return new Bootstrap.BootstrapParams
                {
                    offset = 10,
                    limit = 10,
                    order = "desc",
                    sort = "CreateDate",
                };
            }
        }

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
    }
}