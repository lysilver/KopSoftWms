using System;
using SqlSugar;
using YL.Core.Dto;
using YL.Core.Entity;

namespace IServices
{
    public interface IWms_stockinServices : IBaseServices<Wms_stockin>
    {
        string PageList(PubParams.StockInBootstrapParams bootstrap);

        string PrintList(string stockInId);

        bool Auditin(long UserId, long stockInId);
    }
}