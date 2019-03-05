using IRepository;
using IServices;
using SqlSugar;
using System;
using YL.Core.Entity;
using YL.Utils.Extensions;
using YL.Utils.Json;
using YL.Utils.Pub;
using YL.Utils.Table;

namespace Services
{
    public class Wms_deliveryServices : BaseServices<Wms_delivery>, IWms_deliveryServices
    {
        private readonly IWms_deliveryRepository _repository;
        private readonly SqlSugarClient _client;

        public Wms_deliveryServices(IWms_deliveryRepository repository,
            SqlSugarClient client
            ) : base(repository)
        {
            _repository = repository;
            _client = client;
        }

        public string PageList(Bootstrap.BootstrapParams bootstrap)
        {
            int totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            var query = _client.Queryable<Wms_delivery, Wms_stockout, Wms_Carrier, Sys_user, Sys_user>
                ((s, p, d, c, u) => new object[] {
                   JoinType.Left,s.StockOutId==p.StockOutId,
                   JoinType.Left,s.CarrierId==d.CarrierId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                 })
                 .Where((s, p, d, c, u) => s.IsDel == 1)
                 .Select((s, p, d, c, u) => new
                 {
                     DeliveryId = s.DeliveryId.ToString(),
                     s.DeliveryDate,
                     s.TrackingNo,
                     p.StockOutNo,
                     d.CarrierNo,
                     d.CarrierName,
                     d.CarrierPerson,
                     d.Tel,
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable();
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.TrackingNo.Contains(bootstrap.search) || s.StockOutNo.Contains(bootstrap.search));
            }
            if (!bootstrap.datemin.IsEmpty() && !bootstrap.datemax.IsEmpty())
            {
                query.Where(s => s.CreateDate > bootstrap.datemin.ToDateTimeB() && s.CreateDate <= bootstrap.datemax.ToDateTimeE());
            }
            if (bootstrap.order.Equals("desc", StringComparison.OrdinalIgnoreCase))
            {
                query.OrderBy($"MergeTable.{bootstrap.sort} desc");
            }
            else
            {
                query.OrderBy($"MergeTable.{bootstrap.sort} asc");
            }
            var list = query.ToPageList(bootstrap.offset, bootstrap.limit, ref totalNumber);
            return Bootstrap.GridData(list, totalNumber).JilToJson();
        }

        public bool Delivery(Wms_delivery delivery)
        {
            return _client.Ado.UseTran(() =>
             {
                 _client.Insertable(delivery).ExecuteCommand();
                 _client.Updateable(new Wms_stockout
                 {
                     StockOutId = delivery.StockOutId.Value,
                     StockOutStatus = StockInStatus.delivery.ToByte(),
                     ModifiedBy = delivery.ModifiedBy,
                     ModifiedDate = delivery.ModifiedDate
                 })
                 .UpdateColumns(c =>
                 new
                 {
                     c.StockOutStatus,
                     c.ModifiedBy,
                     c.ModifiedDate
                 }).ExecuteCommand();
             }).IsSuccess;
        }
    }
}