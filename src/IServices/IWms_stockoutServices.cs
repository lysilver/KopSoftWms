using SqlSugar;
using YL.Core.Dto;
using YL.Core.Entity;

namespace IServices
{
    public interface IWms_stockoutServices : IBaseServices<Wms_stockout>
    {
        string PageList(PubParams.StockOutBootstrapParams bootstrap);

        string PrintList(string stockInId);

        DbResult<bool> Auditin(long userId, long stockOutId);
    }
}