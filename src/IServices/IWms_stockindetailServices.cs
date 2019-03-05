using YL.Core.Entity;

namespace IServices
{
    public interface IWms_stockindetailServices : IBaseServices<Wms_stockindetail>
    {
        string PageList(string pid);
    }
}