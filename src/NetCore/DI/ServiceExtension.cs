using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using YL.Utils.Check;
using YL.Utils.Extensions;

namespace YL.NetCore.DI
{
    /// <summary>
    /// net core mvc 容器DI
    /// </summary>
    public static class ServiceExtension
    {
        /// <summary>
        /// 单个注册DI
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="injection"></param>
        public static void Register<TService, TImplementation>(IServiceCollection services, ServiceLifetime injection = ServiceLifetime.Scoped)
        {
            //ServiceCollectionDescriptorExtensions
            switch (injection)
            {
                case ServiceLifetime.Scoped:
                    services.AddScoped(typeof(TService), typeof(TImplementation));
                    break;

                case ServiceLifetime.Singleton:
                    services.AddSingleton(typeof(TService), typeof(TImplementation));
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(typeof(TService), typeof(TImplementation));
                    break;
            }
        }

        //public static void AddService(this IServiceCollection services)
        //{
        //    var defaultAssemblyNames = DependencyContext.Default.GetDefaultAssemblyNames().Where(a => a.FullName.Contains("Services")).ToList();

        //    var assemblies = defaultAssemblyNames.SelectMany(a => AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName("Services")).ExportedTypes.Where(b => b.GetInterfaces().Contains(typeof(IDependency)) && !b.IsAbstract).ToList()).ToList();

        //    assemblies.ForEach(assembliy =>
        //    {
        //        services.AddScoped(assembliy);
        //    });
        //}

        /// <summary>
        ///
        /// </summary>
        /// <param name="service">IServiceCollection</param>
        /// <param name="assemblyName">程序集的名称</param>
        /// <param name="injection">生命周期</param>
        public static void RegisterAssembly(IServiceCollection services, string assemblyName, ServiceLifetime injection = ServiceLifetime.Scoped)
        {
            CheckNull.ArgumentIsNullException(services, nameof(services));
            CheckNull.ArgumentIsNullException(assemblyName, nameof(assemblyName));
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(assemblyName));
            if (assembly.IsNullT())
            {
                throw new ArgumentNullException($"\"{assemblyName}\".dll不存在");
            }
            var types = assembly.GetTypes().Where(o =>
            (typeof(IDependency).IsAssignableFrom(o)) && !o.IsInterface).ToList();
            //&& !o.Name.Contains("Base")
            foreach (var type in types)
            {
                var faces = type.GetInterfaces().Where(o => o.Name != "IDependency" && !o.Name.Contains("Base")).ToArray();
                if (faces.Any())
                {
                    var interfaceType = faces.FirstOrDefault();
                    switch (injection)
                    {
                        case ServiceLifetime.Scoped:
                            services.AddScoped(interfaceType, type);
                            break;

                        case ServiceLifetime.Singleton:
                            services.AddSingleton(interfaceType, type);
                            break;

                        case ServiceLifetime.Transient:
                            services.AddTransient(interfaceType, type);
                            break;
                    }
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="service">IServiceCollection</param>
        /// <param name="assemblyName">dll数组</param>
        /// <param name="injection">生命周期</param>
        public static void RegisterAssembly(IServiceCollection services, string[] assemblyName, ServiceLifetime injection = ServiceLifetime.Singleton)
        {
            CheckNull.ArgumentIsNullException(services, nameof(services));
            CheckNull.ArgumentIsNullException(assemblyName, nameof(assemblyName));
            foreach (var item in assemblyName)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(item));
                if (assembly.IsNullT())
                {
                    throw new ArgumentNullException($"\"{assemblyName}\".dll不存在");
                }
                var types = assembly.GetTypes().Where(o =>
                (typeof(IDependency).IsAssignableFrom(o)) && !o.IsInterface).ToList();
                foreach (var type in types)
                {
                    var faces = type.GetInterfaces().Where(o => o.Name != "IDependency" && !o.Name.Contains("Base")).ToArray();
                    if (faces.Any())
                    {
                        var interfaceType = faces.FirstOrDefault();
                        switch (injection)
                        {
                            case ServiceLifetime.Scoped:
                                services.AddScoped(interfaceType, type);
                                break;

                            case ServiceLifetime.Singleton:
                                services.AddSingleton(interfaceType, type);
                                break;

                            case ServiceLifetime.Transient:
                                services.AddTransient(interfaceType, type);
                                break;
                        }
                    }
                }
            }
        }
    }
}