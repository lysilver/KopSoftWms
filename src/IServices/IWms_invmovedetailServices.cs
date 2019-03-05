using YL.Core.Entity;

namespace IServices
{
    public interface IWms_invmovedetailServices : IBaseServices<Wms_invmovedetail>
    {
        string PageList(string pid);
    }
}