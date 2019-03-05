using YL.Core.Entity;
using YL.Utils.Pub;
using YL.Utils.Table;

namespace IServices
{
    public interface IWms_inventorymoveServices : IBaseServices<Wms_inventorymove>
    {
        string PageList(Bootstrap.BootstrapParams bootstrap);

        bool Auditin(long userId, long InventorymoveId);

        string PrintList(string InventorymoveId);
    }
}