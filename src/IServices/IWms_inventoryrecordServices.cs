using YL.Core.Dto;
using YL.Core.Entity;

namespace IServices
{
    public interface IWms_inventoryrecordServices : IBaseServices<Wms_inventoryrecord>
    {
        string PageList(PubParams.InventoryBootstrapParams bootstrap);
    }
}