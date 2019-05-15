using IRepository;
using IServices;
using Microsoft.AspNetCore.Hosting;
using SqlSugar;
using System;
using System.IO;
using System.Linq;
using YL.Core.Dto;
using YL.Core.Entity;
using YL.Utils.Check;
using YL.Utils.Extensions;
using YL.Utils.Files;
using YL.Utils.Json;
using YL.Utils.Pub;
using YL.Utils.Table;

namespace Services
{
    public class Wms_stockoutServices : BaseServices<Wms_stockout>, IWms_stockoutServices
    {
        private readonly IWms_stockoutRepository _repository;
        private readonly SqlSugarClient _client;
        private readonly IHostingEnvironment _env;
        private readonly IWms_stockoutdetailRepository _detail;
        private readonly IWms_inventoryRepository _inventory;

        public Wms_stockoutServices(SqlSugarClient client,
            IWms_stockoutRepository repository,
            IHostingEnvironment env,
            IWms_stockoutdetailRepository detail,
            IWms_inventoryRepository inventory
            ) : base(repository)
        {
            _client = client;
            _repository = repository;
            _env = env;
            _detail = detail;
            _inventory = inventory;
        }

        public string PageList(PubParams.StockOutBootstrapParams bootstrap)
        {
            int totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            var query = _client.Queryable<Wms_stockout, Wms_Customer, Sys_dict, Sys_user, Sys_user>
                ((s, p, d, c, u) => new object[] {
                   JoinType.Left,s.CustomerId==p.CustomerId,
                   JoinType.Left,s.StockOutType==d.DictId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                 })
                 .Where((s, p, d, c, u) => s.IsDel == 1 && d.IsDel == 1 && c.IsDel == 1)
                 .Select((s, p, d, c, u) => new
                 {
                     StockOutId = s.StockOutId.ToString(),
                     StockOutType = d.DictName,
                     StockOutTypeId = s.StockOutType.ToString(),
                     s.StockOutStatus,
                     s.StockOutNo,
                     s.OrderNo,
                     s.CustomerId,
                     p.CustomerNo,
                     p.CustomerName,
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable();
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.StockOutNo.Contains(bootstrap.search) || s.OrderNo.Contains(bootstrap.search));
            }
            if (!bootstrap.datemin.IsEmpty() && !bootstrap.datemax.IsEmpty())
            {
                query.Where(s => s.CreateDate > bootstrap.datemin.ToDateTimeB() && s.CreateDate <= bootstrap.datemax.ToDateTimeE());
            }
            if (!bootstrap.StockOutType.IsEmpty())
            {
                query.Where((s) => s.StockOutTypeId.Contains(bootstrap.StockOutType));
            }
            if (!bootstrap.StockOutStatus.IsEmpty())
            {
                query.Where((s) => s.StockOutStatus == bootstrap.StockOutStatus.ToByte());
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

        public string PrintList(string stockInId)
        {
            var list1 = _client.Queryable<Wms_stockout, Wms_Customer, Sys_dict, Sys_user, Sys_user>
                ((s, p, d, c, u) => new object[] {
                   JoinType.Left,s.CustomerId==p.CustomerId,
                   JoinType.Left,s.StockOutType==d.DictId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                 })
                 .Where((s, p, d, c, u) => s.IsDel == 1 && d.IsDel == 1)
                 .Select((s, p, d, c, u) => new
                 {
                     StockOutId = s.StockOutId.ToString(),
                     StockOutType = d.DictName,
                     StockOutTypeId = s.StockOutType.ToString(),
                     s.StockOutStatus,
                     s.StockOutNo,
                     s.OrderNo,
                     s.CustomerId,
                     p.CustomerName,
                     p.CustomerNo,
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable().Where(s => s.StockOutId == stockInId).ToList();
            bool flag1 = true;
            bool flag2 = true;
            var list2 = _client.Queryable<Wms_stockoutdetail, Wms_material, Wms_stockout, Wms_storagerack, Sys_user, Sys_user, Sys_user>
                 ((s, m, p, g, c, u, a) => new object[] {
                   JoinType.Left,s.MaterialId==m.MaterialId,
                   JoinType.Left,s.StockOutId==p.StockOutId,
                   JoinType.Left,s.StoragerackId==g.StorageRackId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                   JoinType.Left,s.AuditinId==a.UserId,
                  })
                  .Where((s, m, p, g, c, u, a) => s.IsDel == 1 && m.IsDel == 1 && p.IsDel == 1 && g.IsDel == 1 && c.IsDel == 1)
                  .Select((s, m, p, g, c, u, a) => new
                  {
                      StockOutId = s.StockOutId.ToString(),
                      StockOutDetailId = s.StockOutDetailId.ToString(),
                      m.MaterialNo,
                      m.MaterialName,
                      g.StorageRackNo,
                      g.StorageRackName,
                      Status = SqlFunc.IF(s.Status == 1).Return(StockInStatus.initial.GetDescription())
                      .ElseIF(s.Status == 2).Return(StockInStatus.egis.GetDescription())
                      .ElseIF(s.Status == 3).Return(StockInStatus.auditfailed.GetDescription())
                      .End(StockInStatus.underReview.GetDescription()),
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
                  }).MergeTable().Where(c => c.StockOutId == stockInId).OrderBy(c => c.CreateDate, OrderByType.Desc).ToList();
            if (!list1.Any())
            {
                flag1 = false;
            }
            if (!list2.Any())
            {
                flag2 = false;
            }
            var html = FileUtil.ReadFileFromPath(Path.Combine(_env.WebRootPath, "upload", "StockOut.html"));
            return (flag1, list1, flag2, list2, html).JilToJson();
        }

        public DbResult<bool> Auditin(long userId, long stockOutId)
        {
            var flag = _client.Ado.UseTran(() =>
            {
                //添加库存 如果有则修改 如果没有新增 添加库存明细
                var stockOutDetailList = _client.Queryable<Wms_stockoutdetail>().Where(c => c.StockOutId == stockOutId).ToList();
                var inventory = new Wms_inventory();
                stockOutDetailList.ForEach(c =>
                {
                    var exist = _client.Queryable<Wms_inventory>().Where(i => i.MaterialId == c.MaterialId && i.StoragerackId == c.StoragerackId).First();
                    CheckNull.ArgumentIsNullException(exist, PubConst.StockOut1);
                    if (exist.Qty < c.ActOutQty)
                    {
                        CheckNull.ArgumentIsNullException(PubConst.StockOut2);
                    }
                    //update
                    exist.Qty = exist.Qty - c.ActOutQty;
                    exist.ModifiedBy = userId;
                    exist.ModifiedDate = DateTimeExt.DateTime;
                    _client.Updateable(exist).ExecuteCommand();
                });

                //修改明细状态 2
                _client.Updateable(new Wms_stockoutdetail { Status = StockInStatus.egis.ToByte(), AuditinId = userId, AuditinTime = DateTimeExt.DateTime, ModifiedBy = userId, ModifiedDate = DateTimeExt.DateTime }).UpdateColumns(c => new { c.Status, c.AuditinId, c.AuditinTime, c.ModifiedBy, c.ModifiedDate }).Where(c => c.StockOutId == stockOutId && c.IsDel == 1).ExecuteCommand();

                //修改主表中的状态改为进行中 2
                _client.Updateable(new Wms_stockout { StockOutId = stockOutId, StockOutStatus = StockInStatus.egis.ToByte(), ModifiedBy = userId, ModifiedDate = DateTimeExt.DateTime }).UpdateColumns(c => new { c.StockOutStatus, c.ModifiedBy, c.ModifiedDate }).ExecuteCommand();
            });
            return flag;
        }
    }
}