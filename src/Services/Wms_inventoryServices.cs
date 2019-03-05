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
    public class Wms_inventoryServices : BaseServices<Wms_inventory>, IWms_inventoryServices
    {
        private readonly IWms_inventoryRepository _repository;
        private readonly SqlSugarClient _client;

        public Wms_inventoryServices(
            SqlSugarClient client,
            IWms_inventoryRepository repository) : base(repository)
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
            var query = _client.Queryable<Wms_inventory, Wms_material, Wms_storagerack, Sys_user, Sys_user>
                ((s, p, d, c, u) => new object[] {
                   JoinType.Left,s.MaterialId==p.MaterialId,
                   JoinType.Left,s.StoragerackId==d.StorageRackId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                 })
                 .Where((s, p, d, c, u) => s.IsDel == 1 && d.IsDel == 1 && c.IsDel == 1)
                 .Select((s, p, d, c, u) => new
                 {
                     InventoryId = s.InventoryId.ToString(),
                     s.Qty,
                     MaterialId = p.MaterialId.ToString(),
                     p.MaterialNo,
                     p.MaterialName,
                     SafeQty = p.Qty,
                     StorageRackId = d.StorageRackId.ToString(),
                     d.StorageRackNo,
                     d.StorageRackName,
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable();
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.MaterialNo.Contains(bootstrap.search) || s.MaterialName.Contains(bootstrap.search));
            }
            if (!bootstrap.StorageRackId.IsEmpty())
            {
                query.Where(s => s.StorageRackId == bootstrap.StorageRackId);
            }
            if (!bootstrap.MaterialId.IsEmpty())
            {
                query.Where(s => s.MaterialId == bootstrap.MaterialId);
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

        public string SearchInventory(PubParams.InventoryBootstrapParams bootstrap)
        {
            int totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            var query = _client.Queryable<Wms_inventory, Wms_material, Wms_storagerack, Sys_user, Sys_user>
                ((s, p, d, c, u) => new object[] {
                   JoinType.Left,s.MaterialId==p.MaterialId,
                   JoinType.Left,s.StoragerackId==d.StorageRackId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                 })
                 .Where((s, p, d, c, u) => s.IsDel == 1 && d.IsDel == 1 && c.IsDel == 1)
                 .Select((s, p, d, c, u) => new
                 {
                     InventoryId = s.InventoryId.ToString(),
                     s.Qty,
                     MaterialId = p.MaterialId.ToString(),
                     p.MaterialNo,
                     p.MaterialName,
                     SafeQty = p.Qty,
                     StorageRackId = d.StorageRackId.ToString(),
                     d.StorageRackNo,
                     d.StorageRackName,
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable();
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.MaterialId == bootstrap.search);
            }
            if (!bootstrap.StorageRackId.IsEmpty())
            {
                query.Where((s) => s.StorageRackId == bootstrap.StorageRackId);
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