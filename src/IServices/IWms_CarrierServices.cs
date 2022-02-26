using YL.Core.Entity;
using YL.Utils.Table;

namespace IServices
{
    public interface IWms_CarrierServices : IBaseServices<Wms_Carrier>
    {
        string PageList(Bootstrap.BootstrapParams bootstrap);
    }
}