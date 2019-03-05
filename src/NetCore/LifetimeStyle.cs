namespace YL.NetCore
{
    /// <summary>
    /// using Microsoft.Extensions.DependencyInjection 被系统自带的ServiceLifetime取代，不在使用
    /// </summary>
    public enum LifetimeStyle
    {
        /// <summary>
        /// 实时模式，每次获取都创建不同对象
        /// </summary>
        Transient,

        /// <summary>
        /// 局部模式，同一生命周期获得相同对象，不同生命周期获取不同对象（PerRequest）
        /// </summary>
        Scoped,

        /// <summary>
        /// 单例模式，在第一获取实例时创建，之后都获取相同对象整个应用程序生命周期以内只创建一个实例
        /// </summary>
        Singleton
    }

    public enum AutofacLifetime
    {
        /// <summary>
        /// 默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象；
        /// </summary>
        InstancePerDependency,

        /// <summary>
        /// 同一个Lifetime生成的对象是同一个实例
        /// </summary>
        InstancePerLifetimeScope,

        /// <summary>
        /// 单例模式，每次调用，都会使用同一个实例化的对象；每次都用同一个对象；
        /// </summary>
        SingleInstance
    }
}