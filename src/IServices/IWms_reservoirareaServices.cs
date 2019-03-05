using YL.Core.Entity;
using YL.Utils.Table;

namespace IServices
{
    public interface IWms_reservoirareaServices : IBaseServices<Wms_reservoirarea>
    {
        string PageList(Bootstrap.BootstrapParams bootstrap);
    }
}