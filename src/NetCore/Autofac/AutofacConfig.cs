using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace YL.NetCore.Autofac
{
    public class AutofacConfig
    {
        private static readonly ContainerBuilder containerBuilder = new ContainerBuilder();

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="lifetime"></param>
        public static void Register<T>(T instance, AutofacLifetime lifetime = AutofacLifetime.SingleInstance) where T : class
        {
            //containerBuilder.Register(r => instance).SingleInstance();
            switch (lifetime)
            {
                case AutofacLifetime.InstancePerDependency:
                    containerBuilder.RegisterInstance(instance).InstancePerDependency();
                    break;

                case AutofacLifetime.InstancePerLifetimeScope:
                    containerBuilder.RegisterInstance(instance).InstancePerLifetimeScope();
                    break;

                case AutofacLifetime.SingleInstance:
                    containerBuilder.RegisterInstance(instance).SingleInstance();
                    break;
            }
        }

        public static void Register<T>(AutofacLifetime lifetime = AutofacLifetime.SingleInstance) where T : class
        {
            switch (lifetime)
            {
                case AutofacLifetime.InstancePerDependency:
                    containerBuilder.RegisterType<T>().InstancePerDependency();
                    break;

                case AutofacLifetime.InstancePerLifetimeScope:
                    containerBuilder.RegisterType<T>().InstancePerLifetimeScope();
                    break;

                case AutofacLifetime.SingleInstance:
                    containerBuilder.RegisterType<T>().SingleInstance();
                    break;
            }
        }

        public static void Register(IModule instance)
        {
            containerBuilder.RegisterModule(instance);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TImplementation">接口</typeparam>
        /// <typeparam name="TService">实现</typeparam>
        public static void Register<TImplementation, TService>(AutofacLifetime lifetime = AutofacLifetime.SingleInstance)
        {
            switch (lifetime)
            {
                case AutofacLifetime.InstancePerDependency:
                    containerBuilder.RegisterType<TService>().As<TImplementation>().AsImplementedInterfaces().InstancePerDependency();
                    break;

                case AutofacLifetime.InstancePerLifetimeScope:
                    containerBuilder.RegisterType<TService>().As<TImplementation>().AsImplementedInterfaces().InstancePerLifetimeScope();
                    break;

                case AutofacLifetime.SingleInstance:
                    containerBuilder.RegisterType<TService>().As<TImplementation>().AsImplementedInterfaces().SingleInstance();
                    break;
            }
        }

        /// <summary>
        /// Autofac 必须返回IServiceProvider
        /// </summary>
        /// <param name="services"></param>
        /// <param name="name">dll数组</param>
        /// <returns></returns>
        public static IServiceProvider Register(IServiceCollection services, string[] name, AutofacLifetime lifetime = AutofacLifetime.InstancePerLifetimeScope)
        {
            Type baseType = typeof(IDependency);   //继承IDependency都会注册
            containerBuilder.Populate(services);  //需要
            foreach (var i in name)
            {
                var assemblys = Assembly.Load(i);
                switch (lifetime)
                {
                    case AutofacLifetime.InstancePerDependency:
                        containerBuilder.RegisterAssemblyTypes(assemblys)
                 .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
                 .AsImplementedInterfaces().InstancePerDependency();
                        break;

                    case AutofacLifetime.InstancePerLifetimeScope:
                        containerBuilder.RegisterAssemblyTypes(assemblys)
                 .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
                 .AsImplementedInterfaces().InstancePerLifetimeScope();
                        break;

                    case AutofacLifetime.SingleInstance:
                        containerBuilder.RegisterAssemblyTypes(assemblys)
                 .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
                 .AsImplementedInterfaces().SingleInstance();
                        break;
                }
            }
            var container = containerBuilder.Build();
            ContainerManager.SetContainer(container);//
            //return container.Resolve<IServiceProvider>();
            return new AutofacServiceProvider(container);
        }
    }
}