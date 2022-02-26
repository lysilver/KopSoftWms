using IRepository;
using IServices;
using SqlSugar;
using YL.Core.Entity;
using YL.Utils.Json;
using YL.Utils.Table;

namespace Services
{
    public class Wms_stockoutdetailServices : BaseServices<Wms_stockoutdetail>, IWms_stockoutdetailServices
    {
        private readonly IWms_stockoutdetailRepository _repository;
        private readonly SqlSugarClient _client;

        public Wms_stockoutdetailServices(IWms_stockoutdetailRepository repository,
            SqlSugarClient client
            ) : base(repository)
        {
            _repository = repository;
            _client = client;
        }

        public string PageList(string pid)
        {
            var query = _client.Queryable<Wms_stockoutdetail, Wms_material, Wms_stockout, Wms_storagerack, Sys_user, Sys_user, Sys_user>
               ((s, m, p, g, c, u, a) => new object[] {
                   JoinType.Left,s.MaterialId==m.MaterialId,
                   JoinType.Left,s.StockOutId==p.StockOutId,
                   JoinType.Left,s.StoragerackId==g.StorageRackId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                   JoinType.Left,s.AuditinId==a.UserId,
                })
                .Where((s, m, p, g, c, u, a) => s.IsDel == 1 && m.IsDel == 1 && p.IsDel == 1 && g.IsDel == 1)
                .Select((s, m, p, g, c, u, a) => new
                {
                    StockOutId = s.StockOutId.ToString(),
                    StockOutDetailId = s.StockOutDetailId.ToString(),
                    m.MaterialNo,
                    m.MaterialName,
                    g.StorageRackNo,
                    g.StorageRackName,
                    s.Status,
                    s.PlanOutQty,
                    s.ActOutQty,
                    s.IsDel,
                    s.Remark,
                    s.AuditinTime,
                    AName = a.UserNickname,
                    CName = c.UserNickname,
                    s.CreateDate,
                    UName = u.UserNickname,
                    s.ModifiedDate
                }).MergeTable();
            query.Where(c => c.StockOutId == pid).OrderBy(c => c.CreateDate, OrderByType.Desc);
            var list = query.ToList();
            return Bootstrap.GridData(list, list.Count).JilToJson();
        }
    }
}