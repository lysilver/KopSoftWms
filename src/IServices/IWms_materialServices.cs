using YL.Core.Entity;
using YL.Utils.Table;

namespace IServices
{
    public interface IWms_materialServices : IBaseServices<Wms_material>
    {
        string PageList(Bootstrap.BootstrapParams bootstrap);

        byte[] ExportList(Bootstrap.BootstrapParams bootstrap);
    }
}