using IRepository;
using IServices;
using SqlSugar;
using YL.Core.Entity;
using YL.Utils.Json;
using YL.Utils.Table;

namespace Services
{
    public class Wms_invmovedetailServices : BaseServices<Wms_invmovedetail>, IWms_invmovedetailServices
    {
        private readonly IWms_invmovedetailRepository _repository;
        private readonly SqlSugarClient _client;

        public Wms_invmovedetailServices(IWms_invmovedetailRepository repository
            ,
            SqlSugarClient client) : base(repository)
        {
            _repository = repository;
            _client = client;
        }

        public string PageList(string pid)
        {
            var query = _client.Queryable<Wms_invmovedetail, Wms_material, Wms_inventorymove, Sys_user, Sys_user, Sys_user>
                ((s, m, i, c, u, a) => new object[] {
                   JoinType.Left,s.MaterialId==m.MaterialId,
                   JoinType.Left,s.InventorymoveId==i.InventorymoveId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                   JoinType.Left,s.AuditinId==a.UserId,
                 })
                 .Where((s, m, i, c, u, a) => s.IsDel == 1)
                 .Select((s, m, i, c, u, a) => new
                 {
                     MoveDetailId = s.MoveDetailId.ToString(),
                     InventorymoveId = s.InventorymoveId.ToString(),
                     m.MaterialNo,
                     m.MaterialName,
                     s.Status,
                     s.PlanQty,
                     s.ActQty,
                     s.IsDel,
                     s.Remark,
                     s.AuditinTime,
                     AName = a.UserNickname,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable();
            query.Where(c => c.InventorymoveId == pid).OrderBy(c => c.CreateDate, OrderByType.Desc);
            var list = query.ToList();
            return Bootstrap.GridData(list, list.Count).JilToJson();
        }
    }
}