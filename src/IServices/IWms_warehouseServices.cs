using YL.Core.Entity;
using YL.Utils.Table;

namespace IServices
{
    public interface IWms_warehouseServices : IBaseServices<Wms_warehouse>
    {
        string PageList(Bootstrap.BootstrapParams bootstrap);
    }
}