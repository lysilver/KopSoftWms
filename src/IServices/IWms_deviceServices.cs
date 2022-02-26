using YL.Core.Dto;
using YL.Core.Entity;

namespace IServices
{
    public interface IWms_deviceServices : IBaseServices<Wms_device>
    {
        string PageList(PubParams.DeviceBootstrapParams bootstrap);
    }
}