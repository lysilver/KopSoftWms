using Autofac;
using Microsoft.Extensions.Options;
using System;

namespace YL.NetCore.Autofac
{
    public class ContainerManager
    {
        public static IContainer Container { get; private set; }

        public static void SetContainer(IContainer container)
        {
            Container = container;
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static IOptions<T> ResolveOption<T>() where T : class, new()
        {
            return Resolve<IOptions<T>>();
        }

        public static object Resolve(Type type)
        {
            return Container.Resolve(type);
        }
    }
}