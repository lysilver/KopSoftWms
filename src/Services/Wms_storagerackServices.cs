using IRepository;
using IServices;
using SqlSugar;
using System;
using YL.Core.Entity;
using YL.Utils.Extensions;
using YL.Utils.Json;
using YL.Utils.Table;

namespace Services
{
    public class Wms_storagerackServices : BaseServices<Wms_storagerack>, IWms_storagerackServices
    {
        private readonly IWms_storagerackRepository _repository;
        private readonly SqlSugarClient _client;

        public Wms_storagerackServices(
            SqlSugarClient client,
            IWms_storagerackRepository repository) : base(repository)
        {
            _client = client;
            _repository = repository;
        }

        public string PageList(Bootstrap.BootstrapParams bootstrap)
        {
            int totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            var query = _client.Queryable<Wms_storagerack, Wms_reservoirarea, Wms_warehouse, Sys_user, Sys_user>
                ((s, r, w, c, u) => new object[] {
                   JoinType.Left,s.ReservoirAreaId==r.ReservoirAreaId,
                   JoinType.Left,r.WarehouseId==w.WarehouseId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                 })
                 .Where((s, r, w, c, u) => s.IsDel == 1 && r.IsDel == 1 && w.IsDel == 1)
                 .Select((s, r, w, c, u) => new
                 {
                     StorageRackId = s.StorageRackId.ToString(),
                     s.StorageRackNo,
                     s.StorageRackName,
                     r.ReservoirAreaNo,
                     r.ReservoirAreaName,
                     w.WarehouseNo,
                     w.WarehouseName,
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable();
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.WarehouseName.Contains(bootstrap.search) || s.WarehouseNo.Contains(bootstrap.search));
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