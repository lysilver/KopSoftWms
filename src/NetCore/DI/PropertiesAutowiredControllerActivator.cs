//参考来源：https://blog.csdn.net/u013710468/article/details/83588725
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Internal;
using YL.NetCore.Attributes;

namespace YL.NetCore.DI
{
    /// <summary>
    /// 用于实现属性注入的ControllerActivator
    /// 博客地址:https://www.cnblogs.com/wiseant/p/10515842.html
    ///开源地址https://gitee.com/xant77/CustomAuthorization.WebApi
    /// </summary>
    /// <remarks>
    /// **用法**
    /// 在Startup.ConfigureServices()方法中添加下面一行代码：
    /// services.Replace(ServiceDescriptor.Transient<IControllerActivator, PropertiesAutowiredControllerActivator>());
    /// </remarks>
    public class PropertiesAutowiredControllerActivator : IControllerActivator
    {
        private readonly ITypeActivatorCache _typeActivatorCache;
        private static IDictionary<string, IEnumerable<PropertyInfo>> _publicPropertyCache = new Dictionary<string, IEnumerable<PropertyInfo>>();

        public PropertiesAutowiredControllerActivator(ITypeActivatorCache typeActivatorCache)
        {
            _typeActivatorCache = typeActivatorCache ?? throw new ArgumentNullException(nameof(typeActivatorCache));
        }

        public object Create(ControllerContext controllerContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException(nameof(controllerContext));
            }

            if (controllerContext.ActionDescriptor == null)
            {
                throw new ArgumentException(nameof(ControllerContext.ActionDescriptor));
            }

            var controllerTypeInfo = controllerContext.ActionDescriptor.ControllerTypeInfo;
            if (controllerTypeInfo == null)
            {
                throw new ArgumentException(nameof(controllerContext.ActionDescriptor.ControllerTypeInfo));
            }

            var serviceProvider = controllerContext.HttpContext.RequestServices;
            var instance = _typeActivatorCache.CreateInstance<object>(serviceProvider, controllerTypeInfo.AsType());
            if (instance != null)
            {
                if (!_publicPropertyCache.ContainsKey(controllerTypeInfo.FullName))
                {
                    var ps = controllerTypeInfo.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
                        .Where(c => c.GetCustomAttribute<InjectionAttribute>() != null);
                    _publicPropertyCache[controllerTypeInfo.FullName] = ps;
                }

                var injectionProperties = _publicPropertyCache[controllerTypeInfo.FullName];
                foreach (var item in injectionProperties)
                {
                    var service = serviceProvider.GetService(item.PropertyType);
                    if (service == null)
                    {
                        throw new InvalidOperationException($"Unable to resolve service for type '{item.PropertyType.FullName}' while attempting to activate '{controllerTypeInfo.FullName}'");
                    }
                    item.SetValue(instance, service);
                }
                foreach (FieldInfo field in controllerTypeInfo.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    var autowiredAttr = field.GetCustomAttribute<InjectionAttribute>();
                    if (autowiredAttr != null)
                    {
                        field.SetValue(instance, serviceProvider.GetService(field.FieldType));
                    }
                }
            }
            return instance;
        }

        public void Release(ControllerContext context, object controller)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            if (controller is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}