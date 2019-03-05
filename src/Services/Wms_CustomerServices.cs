using IRepository;
using IServices;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using YL.Core.Entity;
using YL.Core.Entity.Fluent.Validation;
using YL.NetCore.DI;
using YL.Utils.Extensions;
using YL.Utils.Json;
using YL.Utils.Log;
using YL.Utils.Pub;
using YL.Utils.Table;

namespace Services
{
    public class Wms_CustomerServices : BaseServices<Wms_Customer>, IWms_CustomerServices
    {
        private readonly IWms_CustomerRepository _repository;
        private readonly SqlSugarClient _client;

        public Wms_CustomerServices(SqlSugarClient client, IWms_CustomerRepository repository) : base(repository)
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
            var query = _client.Queryable<Wms_Customer, Sys_user, Sys_user>
                ((s, c, u) => new object[] {
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId
                 })
                 .Select((s, c, u) => new
                 {
                     CustomerId = s.CustomerId.ToString(),
                     s.CustomerNo,
                     s.CustomerName,
                     s.Address,
                     s.CustomerPerson,
                     s.CustomerLevel,
                     s.Tel,
                     s.Email,
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable().Where((s) => s.IsDel == 1);
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.CustomerName.Contains(bootstrap.search) || s.CustomerNo.Contains(bootstrap.search));
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

        public (bool, string) Import(System.Data.DataTable dt, long userId)
        {
            if (dt.IsNullDt())
            {
                return (false, PubConst.Import1);
            }
            var validator = new CustomerFluent();
            var list = new List<Wms_Customer>();
            string[] header = { "客户编号", "客户名称", "电话", "邮箱", "联系人", "地址" };
            foreach (var item in header)
            {
                if (!dt.Columns.Contains(item))
                {
                    return (false, "不包含Excel表头:" + string.Join(",", header));
                }
            }
            int dtCount = dt.Rows.Count;
            for (int i = 0; i < dtCount; i++)
            {
                var model = new Wms_Customer
                {
                    CustomerNo = dt.Rows[i]["客户编号"].ToString(),
                    CustomerName = dt.Rows[i]["客户名称"].ToString(),
                    Address = dt.Rows[i]["地址"].ToString(),
                    Tel = dt.Rows[i]["电话"].ToString(),
                    Email = dt.Rows[i]["邮箱"].ToString(),
                    CustomerPerson = dt.Rows[i]["联系人"].ToString(),
                };
                var results = validator.Validate(model);
                var success = results.IsValid;
                if (!success)
                {
                    string msg = results.Errors.Aggregate("", (current, item) => (item.ErrorMessage + "</br>"));
                    return (false, msg);
                }
                if (_repository.IsAny(c => c.CustomerNo == model.CustomerNo))
                {
                    return (false, PubConst.Customer1);
                }
                model.CustomerId = PubId.SnowflakeId;
                model.CreateBy = userId;
                list.Add(model);
            }
            var flag = _repository.InsertTran(list);
            if (flag.IsSuccess)
            {
                return (true, PubConst.Import2);
            }
            else
            {
                var _nlog = ServiceResolve.Resolve<ILogUtil>();
                _nlog.Debug(flag.ErrorMessage);
                return (false, PubConst.Import3);
            }
        }
    }
}