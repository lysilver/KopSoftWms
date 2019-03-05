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
    public class Sys_dictServices : BaseServices<Sys_dict>, ISys_dictServices
    {
        private readonly ISys_dictRepository _repository;
        private readonly SqlSugarClient _client;

        public Sys_dictServices(
            SqlSugarClient client,
            ISys_dictRepository repository) : base(repository)
        {
            _repository = repository;
            _client = client;
        }

        public string PageList(PubParams.DictBootstrapParams bootstrap)
        {
            int totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            var query = _client.Queryable<Sys_dict, Sys_user, Sys_user>
                ((s, c, u) => new object[] {
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId
                 })
                 .Select((s, c, u) => new
                 {
                     DictId = s.DictId.ToString(),
                     s.DictNo,
                     s.DictName,
                     s.DictType,
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable().Where((s) => s.IsDel == 1);
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.DictName.Contains(bootstrap.search));
            }
            if (!bootstrap.DictType.IsEmpty())
            {
                query.Where((s) => s.DictType == bootstrap.DictType);
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