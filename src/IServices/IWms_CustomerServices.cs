using System.Data;
using YL.Core.Entity;
using YL.Utils.Table;

namespace IServices
{
    public interface IWms_CustomerServices : IBaseServices<Wms_Customer>
    {
        string PageList(Bootstrap.BootstrapParams bootstrap);

        (bool, string) Import(DataTable dt, long userId);
    }
}