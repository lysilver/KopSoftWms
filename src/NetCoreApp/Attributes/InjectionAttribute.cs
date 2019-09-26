using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YL.NetCore.Attributes
{
    /// <summary>
    /// [Injection]
    //public ILogUtil log { get; set; }
    //[Injection]
    //public SqlSugar.SqlSugarClient client { get; set; }
    /// 在属性上添加此特性，以声明该属性需要使用依赖注入
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class InjectionAttribute : Attribute { }
}