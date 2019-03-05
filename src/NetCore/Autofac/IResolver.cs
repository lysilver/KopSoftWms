using System;
using System.Collections.Generic;
using System.Text;

namespace YL.NetCore.Autofac
{
    public interface IResolver
    {
        T Resolve<T>();

        IEnumerable<T> ResolveAll<T>();
    }
}