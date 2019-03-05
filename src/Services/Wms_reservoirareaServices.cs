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
    public class Wms_reservoirareaServices : BaseServices<Wms_reservoirarea>, IWms_reservoirareaServices
    {
        private readonly IWms_reservoirareaRepository _repository;
        private readonly SqlSugarClient _client;

        public Wms_reservoirareaServices(SqlSugarClient client, IWms_reservoirareaRepository repository) : base(repository)
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
            var query = _client.Queryable<Wms_reservoirarea, Sys_user, Sys_user, Wms_warehouse>
                ((s, c, u, w) => new object[] {
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                   JoinType.Left,s.WarehouseId==w.WarehouseId
                 })
                 .Select((s, c, u, w) => new
                 {
                     ReservoirAreaId = s.ReservoirAreaId.ToString(),
                     s.ReservoirAreaNo,
                     s.ReservoirAreaName,
                     w.WarehouseNo,
                     w.WarehouseName,
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable().Where((s) => s.IsDel == 1);
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