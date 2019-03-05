using YL.Core.Dto;
using YL.Core.Entity;

namespace IServices
{
    public interface IWms_inventoryServices : IBaseServices<Wms_inventory>
    {
        string PageList(PubParams.InventoryBootstrapParams bootstrap);

        string SearchInventory(PubParams.InventoryBootstrapParams bootstrap);
    }
}