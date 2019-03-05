using YL.Core.Entity;
using YL.Core.Dto;

namespace IServices
{
    public interface IWms_deviceServices : IBaseServices<Wms_device>
    {
        string PageList(PubParams.DeviceBootstrapParams bootstrap);
    }
}