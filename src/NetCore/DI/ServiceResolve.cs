using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace YL.NetCore.DI
{
    /// <summary>
    /// 使用DI
    /// </summary>
    public class ServiceResolve
    {
        private static IServiceProvider _serviceProvider = null;

        /// <summary>
        /// services.BuildServiceProvider()
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void SetServiceResolve(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T Resolve<T>() where T : class
        {
            return _serviceProvider.GetService<T>();
        }

        public static T ResolveS<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public static IOptions<T> ResolveOption<T>() where T : class, new()
        {
            return _serviceProvider.GetService<IOptions<T>>();
        }

        public static T ResolveA<T>() where T : class
        {
            return _serviceProvider == null ? null : ActivatorUtilities.GetServiceOrCreateInstance<T>(_serviceProvider);
        }
    }
}