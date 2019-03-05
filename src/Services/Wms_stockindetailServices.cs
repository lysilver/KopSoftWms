using IRepository;
using IServices;
using YL.Core.Entity;
using YL.Utils.Table;
using SqlSugar;
using System;
using YL.Utils.Json;

namespace Services
{
    public class Wms_stockindetailServices : BaseServices<Wms_stockindetail>, IWms_stockindetailServices
    {
        private readonly IWms_stockindetailRepository _repository;
        private readonly SqlSugarClient _client;

        public Wms_stockindetailServices(SqlSugarClient client, IWms_stockindetailRepository repository) : base(repository)
        {
            _client = client;
            _repository = repository;
        }

        public string PageList(string pid)
        {
            var query = _client.Queryable<Wms_stockindetail, Wms_material, Wms_stockin, Wms_storagerack, Sys_user, Sys_user, Sys_user>
                ((s, m, p, g, c, u, a) => new object[] {
                   JoinType.Left,s.MaterialId==m.MaterialId,
                   JoinType.Left,s.StockInId==p.StockInId,
                   JoinType.Left,s.StoragerackId==g.StorageRackId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                   JoinType.Left,s.AuditinId==a.UserId,
                 })
                 .Where((s, m, p, g, c, u, a) => s.IsDel == 1 && p.IsDel == 1 && g.IsDel == 1 && c.IsDel == 1)
                 .Select((s, m, p, g, c, u, a) => new
                 {
                     StockInId = s.StockInId.ToString(),
                     StockInDetailId = s.StockInDetailId.ToString(),
                     m.MaterialNo,
                     m.MaterialName,
                     g.StorageRackNo,
                     g.StorageRackName,
                     s.Status,
                     s.PlanInQty,
                     s.ActInQty,
                     s.IsDel,
                     s.Remark,
                     s.AuditinTime,
                     AName = a.UserNickname,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable();
            query.Where(c => c.StockInId == pid).OrderBy(c => c.CreateDate, OrderByType.Desc);
            //if (bootstrap.order.Equals("desc", StringComparison.OrdinalIgnoreCase))
            //{
            //    query.OrderBy($"MergeTable.{bootstrap.sort} desc");
            //}
            //else
            //{
            //    query.OrderBy($"MergeTable.{bootstrap.sort} asc");
            //}
            //var list = query.ToPageList(bootstrap.offset, bootstrap.limit, ref totalNumber);
            var list = query.ToList();
            return Bootstrap.GridData(list, list.Count).JilToJson();
        }
    }
}