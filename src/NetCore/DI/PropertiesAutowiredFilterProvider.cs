using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using YL.NetCore.Attributes;

namespace YL.NetCore.DI
{
    /// <summary>
    /// 用于实现属性注入的FilterProvider
    /// /// 博客地址:https://www.cnblogs.com/wiseant/p/10515842.html
    ///开源地址https://gitee.com/xant77/CustomAuthorization.WebApi
    /// </summary>
    /// <remarks>
    /// **用法**
    /// 在Startup.ConfigureServices()方法中添加下面一行代码：
    /// services.Replace(ServiceDescriptor.Transient<IFilterProvider, PropertiesAutowiredFilterProvider>());
    /// </remarks>
    public class PropertiesAutowiredFilterProvider : DefaultFilterProvider
    {
        private static IDictionary<string, IEnumerable<PropertyInfo>> _publicPropertyCache = new Dictionary<string, IEnumerable<PropertyInfo>>();

        public override void ProvideFilter(FilterProviderContext context, FilterItem filterItem)
        {
            base.ProvideFilter(context, filterItem); //在调用基类方法之前filterItem变量不会有值
            var filterType = filterItem.Filter.GetType();
            if (!_publicPropertyCache.ContainsKey(filterType.FullName))
            {
                var ps = filterType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(c => c.GetCustomAttribute<InjectionAttribute>() != null);
                _publicPropertyCache[filterType.FullName] = ps;
            }

            var injectionProperties = _publicPropertyCache[filterType.FullName];
            if (injectionProperties?.Count() == 0)
                return;
            //下面是注入属性实例的关键代码
            var serviceProvider = context.ActionContext.HttpContext.RequestServices;
            foreach (var item in injectionProperties)
            {
                var service = serviceProvider.GetService(item.PropertyType);
                if (service == null)
                {
                    throw new InvalidOperationException($"Unable to resolve service for type '{item.PropertyType.FullName}' while attempting to activate '{filterType.FullName}'");
                }
                item.SetValue(filterItem.Filter, service);
            }
        }
    }
}