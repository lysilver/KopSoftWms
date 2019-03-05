using IRepository;
using IServices;
using SqlSugar;
using System;
using YL.Core.Dto;
using YL.Core.Entity;
using YL.Utils.Extensions;
using YL.Utils.Json;
using YL.Utils.Table;

namespace Services
{
    public class Wms_inventoryrecordServices : BaseServices<Wms_inventoryrecord>, IWms_inventoryrecordServices
    {
        private readonly IWms_inventoryrecordRepository _repository;
        private readonly SqlSugarClient _client;

        public Wms_inventoryrecordServices(
            SqlSugarClient client,
            IWms_inventoryrecordRepository repository) : base(repository)
        {
            _client = client;
            _repository = repository;
        }

        public string PageList(PubParams.InventoryBootstrapParams bootstrap)
        {
            int totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            var query = _client.Queryable<Wms_inventoryrecord, Wms_stockindetail, Wms_material, Sys_user, Sys_user, Wms_stockin, Wms_storagerack>
                ((s, p, d, c, u, i, w) => new object[] {
                   JoinType.Left,s.StockInDetailId==p.StockInDetailId,
                   JoinType.Left,p.MaterialId==d.MaterialId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                   JoinType.Left,p.StockInId==i.StockInId,
                   JoinType.Left,w.StorageRackId==p.StoragerackId
                 })
                 .Where((s, p, d, c, u, i, w) => s.IsDel == 1 && d.IsDel == 1 && c.IsDel == 1 && i.IsDel == 1 && w.IsDel == 1)
                 .Select((s, p, d, c, u, i, w) => new
                 {
                     InventoryrecordId = s.InventoryrecordId.ToString(),
                     i.StockInNo,
                     s.Qty,
                     d.MaterialNo,
                     d.MaterialName,
                     w.StorageRackNo,
                     w.StorageRackName,
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable();
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.MaterialNo.Contains(bootstrap.search) || s.MaterialName.Contains(bootstrap.search) || s.StockInNo.Contains(bootstrap.search));
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
    }
}