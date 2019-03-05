using IRepository;
using IServices;
using Microsoft.AspNetCore.Hosting;
using SqlSugar;
using System;
using System.IO;
using System.Linq;
using YL.Core.Entity;
using YL.Utils.Check;
using YL.Utils.Extensions;
using YL.Utils.Files;
using YL.Utils.Json;
using YL.Utils.Pub;
using YL.Utils.Table;

namespace Services
{
    public class Wms_inventorymoveServices : BaseServices<Wms_inventorymove>, IWms_inventorymoveServices
    {
        private readonly IWms_inventorymoveRepository _repository;
        private readonly SqlSugarClient _client;
        private readonly IHostingEnvironment _env;

        public Wms_inventorymoveServices(IWms_inventorymoveRepository repository,
            SqlSugarClient client,
            IHostingEnvironment env
            ) : base(repository)
        {
            _repository = repository;
            _client = client;
            _env = env;
        }

        public string PageList(Bootstrap.BootstrapParams bootstrap)
        {
            int totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            var query = _client.Queryable<Wms_inventorymove, Wms_storagerack, Wms_storagerack, Sys_user, Sys_user>
                ((w, s, a, c, u) => new object[] {
                   JoinType.Left,w.SourceStoragerackId==s.StorageRackId,
                   JoinType.Left,w.AimStoragerackId==a.StorageRackId,
                   JoinType.Left,w.CreateBy==c.UserId,
                   JoinType.Left,w.ModifiedBy==u.UserId,
                 })
                 .Where((w, s, a, c, u) => w.IsDel == 1)
                 .Select((w, s, a, c, u) => new
                 {
                     InventorymoveId = w.InventorymoveId.ToString(),
                     w.InventorymoveNo,
                     w.Status,
                     SourceStorageRackNo = s.StorageRackNo,
                     SourceStorageRackName = s.StorageRackName,
                     AimStorageRackNo = a.StorageRackNo,
                     AimStorageRackName = a.StorageRackName,
                     w.IsDel,
                     w.Remark,
                     CName = c.UserNickname,
                     w.CreateDate,
                     UName = u.UserNickname,
                     w.ModifiedDate
                 }).MergeTable();
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.InventorymoveNo.Contains(bootstrap.search));
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
            return Bootstrap.GridData(list, totalNumber).ToJsonL();
            //return Bootstrap.GridData(list, totalNumber).JilToJson();
        }

        public bool Auditin(long userId, long InventorymoveId)
        {
            var flag = _client.Ado.UseTran(() =>
            {
                var invmovedetailList = _client.Queryable<Wms_invmovedetail>().Where(c => c.InventorymoveId == InventorymoveId).ToList();
                var invmove = _client.Queryable<Wms_inventorymove>().Where(c => c.InventorymoveId == InventorymoveId).First();
                invmovedetailList.ForEach(c =>
                {
                    var exist = _client.Queryable<Wms_inventory>().Where(i => i.MaterialId == c.MaterialId && i.StoragerackId == invmove.SourceStoragerackId).First();
                    CheckNull.ArgumentIsNullException(exist, PubConst.StockOut1);
                    if (exist.Qty < c.ActQty)
                    {
                        CheckNull.ArgumentIsNullException(PubConst.StockOut2);
                    }
                    //update
                    exist.Qty = exist.Qty - c.ActQty;
                    exist.ModifiedBy = userId;
                    exist.ModifiedDate = DateTimeExt.DateTime;
                    _client.Updateable(exist).ExecuteCommand();
                    exist = _client.Queryable<Wms_inventory>().Where(i => i.MaterialId == c.MaterialId && i.StoragerackId == invmove.AimStoragerackId).First();
                    if (exist == null)
                    {
                        _client.Insertable(new Wms_inventory
                        {
                            StoragerackId = invmove.AimStoragerackId,
                            CreateBy = userId,
                            InventoryId = PubId.SnowflakeId,
                            MaterialId = c.MaterialId,
                            Qty = c.ActQty,
                        }).ExecuteCommand();
                    }
                    else
                    {
                        exist.Qty += c.ActQty;
                        exist.ModifiedBy = userId;
                        exist.ModifiedDate = DateTimeExt.DateTime;
                        _client.Updateable(exist).ExecuteCommand();
                    }
                });

                //修改明细状态 2
                _client.Updateable(new Wms_invmovedetail { Status = StockInStatus.egis.ToByte(), AuditinId = userId, AuditinTime = DateTimeExt.DateTime, ModifiedBy = userId, ModifiedDate = DateTimeExt.DateTime }).UpdateColumns(c => new { c.Status, c.AuditinId, c.AuditinTime, c.ModifiedBy, c.ModifiedDate }).Where(c => c.InventorymoveId == InventorymoveId && c.IsDel == 1).ExecuteCommand();

                //修改主表中的状态改为进行中 2
                _client.Updateable(new Wms_inventorymove { InventorymoveId = InventorymoveId, Status = StockInStatus.egis.ToByte(), ModifiedBy = userId, ModifiedDate = DateTimeExt.DateTime }).UpdateColumns(c => new { c.Status, c.ModifiedBy, c.ModifiedDate }).ExecuteCommand();
            }).IsSuccess;
            return flag;
        }

        public string PrintList(string InventorymoveId)
        {
            var list1 = _client.Queryable<Wms_inventorymove, Wms_storagerack, Wms_storagerack, Sys_user, Sys_user>
                ((s, p, d, c, u) => new object[] {
                   JoinType.Left,s.SourceStoragerackId==p.StorageRackId,
                   JoinType.Left,s.AimStoragerackId==p.StorageRackId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId
                 })
                 .Where((s, p, d, c, u) => s.IsDel == 1)
                 .Select((s, p, d, c, u) => new
                 {
                     InventorymoveId = s.InventorymoveId.ToString(),
                     s.Status,
                     s.InventorymoveNo,
                     SourceStoragerackId = s.SourceStoragerackId.ToString(),
                     SourceStoragerackNo = p.StorageRackNo.ToString(),
                     SourceStoragerackName = p.StorageRackName.ToString(),
                     AimStoragerackId = s.AimStoragerackId.ToString(),
                     AimStoragerackNo = d.StorageRackNo.ToString(),
                     AimStoragerackName = d.StorageRackName.ToString(),
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable().Where(s => s.InventorymoveId == InventorymoveId).ToList();
            bool flag1 = true;
            bool flag2 = true;
            var list2 = _client.Queryable<Wms_invmovedetail, Wms_material, Wms_inventorymove, Sys_user, Sys_user, Sys_user>
                 ((s, m, p, c, u, a) => new object[] {
                   JoinType.Left,s.MaterialId==m.MaterialId,
                   JoinType.Left,s.InventorymoveId==p.InventorymoveId,
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                   JoinType.Left,s.AuditinId==a.UserId,
                  })
                  .Where((s, m, p, c, u, a) => s.IsDel == 1)
                  .Select((s, m, p, c, u, a) => new
                  {
                      InventorymoveId = s.InventorymoveId.ToString(),
                      MoveDetailId = s.MoveDetailId.ToString(),
                      m.MaterialNo,
                      m.MaterialName,
                      Status = SqlFunc.IF(s.Status == 1).Return(StockInStatus.initial.GetDescription())
                      .ElseIF(s.Status == 2).Return(StockInStatus.egis.GetDescription())
                      .ElseIF(s.Status == 3).Return(StockInStatus.auditfailed.GetDescription())
                      .End(StockInStatus.underReview.GetDescription()),
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
                  }).MergeTable().Where(c => c.InventorymoveId == InventorymoveId).OrderBy(c => c.CreateDate, OrderByType.Desc).ToList();
            if (!list1.Any())
            {
                flag1 = false;
            }
            if (!list2.Any())
            {
                flag2 = false;
            }
            var html = FileUtil.ReadFileFromPath(Path.Combine(_env.WebRootPath, "upload", "InvMove.html"));
            return (flag1, list1, flag2, list2, html).JilToJson();
        }
    }
}