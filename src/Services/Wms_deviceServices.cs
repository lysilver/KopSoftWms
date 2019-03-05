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
    public class Wms_deviceServices : BaseServices<Wms_device>, IWms_deviceServices
    {
        private readonly IWms_deviceRepository _repository;
        private readonly SqlSugarClient _client;

        public Wms_deviceServices(SqlSugarClient client, IWms_deviceRepository repository) : base(repository)
        {
            _client = client;
            _repository = repository;
        }

        public string PageList(PubParams.DeviceBootstrapParams bootstrap)
        {
            int totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            var query = _client.Queryable<Wms_device, Sys_dept, Sys_dict, Sys_dict, Sys_user, Sys_user>
                ((s, p, t, d, c, u) => new object[] {
                   JoinType.Left,s.DeptId==p.DeptId,
                   JoinType.Left,s.DeviceType==t.DictId,
                   JoinType.Left,s.PropertyType==d.DictId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                 })
                 .Where((s, p, t, d, c, u) => s.IsDel == 1 && p.IsDel == 1 && t.IsDel == 1 && d.IsDel == 1 && c.IsDel == 1)
                 .Select((s, p, t, d, c, u) => new
                 {
                     DeviceId = s.DeviceId.ToString(),
                     s.PlatformNo,
                     s.SerialNo,
                     p.DeptName,
                     DeptId = p.DeptId.ToString(),
                     DeviceType = t.DictName,
                     DeviceTypeId = s.DeviceType.ToString(),
                     PropertyType = d.DictName,
                     PropertyTypeId = s.PropertyType.ToString(),
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable();
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.PlatformNo.Contains(bootstrap.search) || s.SerialNo.Contains(bootstrap.search));
            }
            if (!bootstrap.datemin.IsEmpty() && !bootstrap.datemax.IsEmpty())
            {
                query.Where(s => s.CreateDate > bootstrap.datemin.ToDateTimeB() && s.CreateDate <= bootstrap.datemax.ToDateTimeE());
            }
            if (!bootstrap.DeptId.IsEmpty())
            {
                query.Where((s) => s.DeptId.Contains(bootstrap.DeptId));
            }
            if (!bootstrap.DeviceType.IsEmpty())
            {
                query.Where((s) => s.DeviceTypeId.Contains(bootstrap.DeviceType));
            }
            if (!bootstrap.PropertyType.IsEmpty())
            {
                query.Where((s) => s.PropertyTypeId.Contains(bootstrap.PropertyType));
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