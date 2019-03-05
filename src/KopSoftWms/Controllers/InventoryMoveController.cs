using Microsoft.AspNetCore.Mvc;
using YL.NetCore.Attributes;
using YL.NetCore.NetCoreApp;
using IServices;
using YL.Utils.Table;
using YL.Utils.Pub;
using YL.Utils.Extensions;
using YL.Core.Dto;
using YL.Core.Entity;
using YL.Core.Entity.Fluent.Validation;
using System.Linq;
using SqlSugar;
using System.Collections.Generic;
using YL.Utils.Security;

namespace KopSoftWms.Controllers
{
    public class InventoryMoveController : BaseController
    {
        private readonly IWms_inventorymoveServices _inventorymoveServices;
        private readonly IWms_invmovedetailServices _invmovedetailServices;
        private readonly ISys_serialnumServices _serialnumServices;
        private readonly Xss _xss;
        private readonly SqlSugarClient _client;
        private readonly IWms_materialServices _materialServices;
        private readonly IWms_inventoryServices _inventoryServices;

        public InventoryMoveController(
            IWms_inventorymoveServices inventorymoveServices,
            IWms_invmovedetailServices invmovedetailServices,
            ISys_serialnumServices serialnumServices,
            Xss xss,
            SqlSugarClient client,
            IWms_materialServices materialServices,
            IWms_inventoryServices inventoryServices
            )
        {
            _inventorymoveServices = inventorymoveServices;
            _invmovedetailServices = invmovedetailServices;
            _serialnumServices = serialnumServices;
            _materialServices = materialServices;
            _xss = xss;
            _client = client;
            _inventoryServices = inventoryServices;
        }

        [HttpGet]
        [CheckMenu]
        public IActionResult Index()
        {
            var status = EnumExt.ToKVListLinq<StockInStatus>();
            ViewBag.Status = status;
            return View();
        }

        /// <summary>
        /// 主表
        /// </summary>
        /// <param name="bootstrap">参数</param>
        /// <returns></returns>
        [HttpPost]
        [OperationLog(LogType.select)]
        public ContentResult List([FromForm]PubParams.StatusBootstrapParams bootstrap)
        {
            var sd = _inventorymoveServices.PageList(bootstrap);
            return Content(sd);
        }

        /// <summary>
        /// 明细
        /// </summary>
        /// <param name="id">主表id</param>
        /// <returns></returns>
        [HttpPost]
        [OperationLog(LogType.select)]
        public ContentResult ListDetail(string pid)
        {
            var sd = _invmovedetailServices.PageList(pid);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            var model = new Wms_inventorymove();
            if (id.IsEmpty())
            {
                return View(model);
            }
            else
            {
                model = _inventorymoveServices.QueryableToEntity(c => c.InventorymoveId == SqlFunc.ToInt64(id) && c.IsDel == 1);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Detail(string id, string pid)
        {
            var model = new Wms_invmovedetailDto();
            var head = _inventorymoveServices.QueryableToEntity(c => c.InventorymoveId == SqlFunc.ToInt64(pid) && c.IsDel == 1);
            model.AimStoragerackId = head.AimStoragerackId;
            model.SourceStoragerackId = head.SourceStoragerackId;
            if (id.IsEmptyZero())
            {
                model.Pid = pid;
                return View(model);
            }
            else
            {
                var detail = _invmovedetailServices.QueryableToList(c => c.InventorymoveId == SqlFunc.ToInt64(pid) && c.IsDel == 1);
                model.Pid = pid;
                model.Detail = detail.Select(c => new Wmsinvmovedetail
                {
                    MaterialId = c.MaterialId.ToString(),
                    MaterialNo = _materialServices.QueryableToEntity(m => m.MaterialId == c.MaterialId).MaterialNo,
                    MaterialName = _materialServices.QueryableToEntity(m => m.MaterialId == c.MaterialId).MaterialName,
                    ActQty = c.ActQty,
                    Qty = _inventoryServices.QueryableToEntity(m => m.MaterialId == c.MaterialId && m.StoragerackId == model.SourceStoragerackId).Qty,
                    AuditinId = c.AuditinId.ToString(),
                    AuditinTime = c.AuditinTime,
                    CreateBy = c.CreateBy.ToString(),
                    CreateDate = c.CreateDate,
                    InventorymoveId = c.InventorymoveId.ToString(),
                    IsDel = c.IsDel,
                    ModifiedBy = c.ModifiedBy.ToString(),
                    MoveDetailId = c.MoveDetailId.ToString(),
                    ModifiedDate = c.ModifiedDate,
                    PlanQty = c.PlanQty,
                    Remark = c.Remark,
                    Status = c.Status,
                }).ToList();
                return View(model);
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Wms_inventorymove model, [FromForm]string id)
        {
            var validator = new InventoryMoveFluent();
            var results = validator.Validate(model);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                model.InventorymoveNo = _serialnumServices.GetSerialnum(UserDtoCache.UserId, "Wms_inventorymove");
                model.InventorymoveId = PubId.SnowflakeId;
                model.Status = StockInStatus.initial.ToByte();
                model.CreateBy = UserDtoCache.UserId;
                bool flag = _inventorymoveServices.Insert(model);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                model.InventorymoveId = id.ToInt64();
                model.ModifiedBy = UserDtoCache.UserId;
                model.ModifiedDate = DateTimeExt.DateTime;
                var flag = _inventorymoveServices.Update(model);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpPost]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdateD([FromForm]List<Wms_invmovedetail> list, [FromForm]string id)
        {
            var validator = new InvmovedetailFluent();
            foreach (var c in list)
            {
                var results = validator.Validate(c);
                var success = results.IsValid;
                if (!success)
                {
                    string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                    return BootJsonH((PubEnum.Failed.ToInt32(), msg));
                }
            }
            var exist = _invmovedetailServices.QueryableToList(c => c.InventorymoveId == SqlFunc.ToInt64(id));
            var modelList = new List<Wms_invmovedetail>();
            if (exist.IsNullT())
            {
                list.ForEach((c) =>
                {
                    c.Remark = _xss.Filter(c.Remark);
                    c.MoveDetailId = PubId.SnowflakeId;
                    c.Status = StockInStatus.initial.ToByte();
                    c.IsDel = 1;
                    c.CreateBy = UserDtoCache.UserId;
                    c.CreateDate = DateTimeExt.DateTime;
                    modelList.Add(c);
                });
                bool flag = _invmovedetailServices.Insert(modelList);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                _invmovedetailServices.Update(new Wms_invmovedetail { IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate }, c => c.InventorymoveId == SqlFunc.ToInt64(id) && c.IsDel == 1);
                list.ForEach((c) =>
                {
                    c.Remark = _xss.Filter(c.Remark);
                    c.Status = StockInStatus.initial.ToByte();
                    c.MoveDetailId = PubId.SnowflakeId;
                    c.IsDel = 1;
                    c.CreateBy = UserDtoCache.UserId;
                    c.CreateDate = DateTimeExt.DateTime;
                    modelList.Add(c);
                });

                var flag = _invmovedetailServices.Insert(modelList);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [OperationLog(LogType.update)]
        public IActionResult Auditin(string id)
        {
            var list = _invmovedetailServices.QueryableToList(c => c.IsDel == 1 && c.InventorymoveId == SqlFunc.ToInt64(id));
            if (!list.Any())
            {
                return BootJsonH((false, PubConst.StockIn4));
            }
            var flag = _inventorymoveServices.Auditin(UserDtoCache.UserId, SqlFunc.ToInt64(id));
            return BootJsonH(flag ? (flag, PubConst.StockIn2) : (flag, PubConst.StockIn3));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主表id</param>
        /// <returns></returns>
        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            var flag = _client.Ado.UseTran(() =>
            {
                _client.Updateable(new Wms_invmovedetail { IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime })
                .UpdateColumns(c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate }).Where(c => c.InventorymoveId == SqlFunc.ToInt64(id) && c.IsDel == 1).ExecuteCommand();

                _client.Updateable(new Wms_inventorymove { InventorymoveId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }).UpdateColumns(c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate }).ExecuteCommand();
            }).IsSuccess;
            return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
        }

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="id">明细id</param>
        /// <returns></returns>
        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult DeleteDetail(string id)
        {
            var flag = _invmovedetailServices.Update(
                 new Wms_invmovedetail { IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime },
                 c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate },
                 c => c.MoveDetailId == SqlFunc.ToInt64(id)
                 );
            return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
        }

        [HttpGet]
        public IActionResult PreviewJson(string id)
        {
            var str = _inventorymoveServices.PrintList(id);
            return Content(str);
        }
    }
}