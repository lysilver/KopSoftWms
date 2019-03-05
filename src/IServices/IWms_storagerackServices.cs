using System;
using System.Linq.Expressions;
using YL.Core.Entity;
using YL.Utils.Table;

namespace IServices
{
    public interface IWms_storagerackServices : IBaseServices<Wms_storagerack>
    {
        string PageList(Bootstrap.BootstrapParams bootstrap);
    }
}