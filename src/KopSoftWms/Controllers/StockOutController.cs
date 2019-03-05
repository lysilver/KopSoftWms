using IServices;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Linq;
using YL.Core.Dto;
using YL.Core.Entity;
using YL.Core.Entity.Fluent.Validation;
using YL.NetCore.Attributes;
using YL.NetCore.NetCoreApp;
using YL.Utils.Extensions;
using YL.Utils.Pub;
using YL.Utils.Table;

namespace KopSoftWms.Controllers
{
    public class StockOutController : BaseController
    {
        private readonly ISys_dictServices _dictServices;
        private readonly IWms_CustomerServices _customerServices;
        private readonly IWms_stockoutServices _stockoutServices;
        private readonly ISys_serialnumServices _serialnumServices;
        private readonly IWms_stockoutdetailServices _stockoutdetailServices;
        private readonly IWms_inventoryServices _inventoryServices;
        private readonly SqlSugarClient _client;

        public StockOutController(
            ISys_dictServices dictServices,
            IWms_CustomerServices customerServices,
            IWms_stockoutServices stockoutServices,
            ISys_serialnumServices serialnumServices,
            IWms_stockoutdetailServices stockoutdetailServices,
            IWms_inventoryServices inventoryServices,
            SqlSugarClient client
            )
        {
            _dictServices = dictServices;
            _customerServices = customerServices;
            _stockoutServices = stockoutServices;
            _serialnumServices = serialnumServices;
            _stockoutdetailServices = stockoutdetailServices;
            _inventoryServices = inventoryServices;
            _client = client;
        }

        [HttpGet]
        [CheckMenu]
        public IActionResult Index()
        {
            var list = _dictServices.Queryable().Where(c => c.IsDel == 1 && c.DictType == PubDictType.stockout.ToString()).ToList();
            var stockInStatus = EnumExt.ToKVListLinq<StockInStatus>();
            ViewBag.StockInType = list;
            ViewBag.StockInStatus = stockInStatus;
            return View();
        }

        [HttpGet]
        public IActionResult Search(string text)
        {
            var bootstrap = new Bootstrap.BootstrapParams
            {
                limit = 100,
                offset = 0,
                sort = "CreateDate",
                search = text,
                order = "desc"
            };
            var json = _customerServices.PageList(bootstrap);
            return Content(json);
        }

        [HttpGet]
        public IActionResult SearchInventory(string id, string storagerackId)
        {
            var bootstrap = new PubParams.InventoryBootstrapParams
            {
                limit = 100,
                offset = 0,
                sort = "CreateDate",
                search = id,
                order = "desc",
                StorageRackId = storagerackId,
            };
            var json = _inventoryServices.SearchInventory(bootstrap);
            return Content(json);
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            var model = new Wms_stockout();
            if (id.IsEmpty())
            {
                return View(model);
            }
            else
            {
                model = _stockoutServices.QueryableToEntity(c => c.StockOutId == SqlFunc.ToInt64(id) && c.IsDel == 1);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Detail(string id, string pid)
        {
            var model = new Wms_stockoutdetail();
            if (id.IsEmptyZero())
            {
                model.StockOutId = pid.ToInt64();
                return View(model);
            }
            else
            {
                model = _stockoutdetailServices.QueryableToEntity(c => c.StockOutDetailId == SqlFunc.ToInt64(id) && c.IsDel == 1);
                return View(model);
            }
        }

        /// <summary>
        /// 主表
        /// </summary>
        /// <param name="bootstrap">参数</param>
        /// <returns></returns>
        [HttpPost]
        [OperationLog(LogType.select)]
        public ContentResult List([FromForm]PubParams.StockOutBootstrapParams bootstrap)
        {
            var sd = _stockoutServices.PageList(bootstrap);
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
            var sd = _stockoutdetailServices.PageList(pid);
            return Content(sd);
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Wms_stockout model, [FromForm]string id)
        {
            var validator = new StockOutFluent();
            var results = validator.Validate(model);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (!model.OrderNo.IsEmpty())
                {
                    if (_stockoutServices.IsAny(c => c.OrderNo == model.OrderNo))
                    {
                        return BootJsonH((false, PubConst.StockIn1));
                    }
                }
                model.StockOutNo = _serialnumServices.GetSerialnum(UserDtoCache.UserId, "Wms_stockout");
                model.StockOutId = PubId.SnowflakeId;
                model.StockOutStatus = StockInStatus.initial.ToByte();
                model.CreateBy = UserDtoCache.UserId;
                bool flag = _stockoutServices.Insert(model);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                model.StockOutId = id.ToInt64();
                model.ModifiedBy = UserDtoCache.UserId;
                model.ModifiedDate = DateTimeExt.DateTime;
                var flag = _stockoutServices.Update(model);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdateD([FromForm]Wms_stockoutdetail model, [FromForm]string id)
        {
            var validator = new StockOutDetailFluent();
            var results = validator.Validate(model);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                model.StockOutDetailId = PubId.SnowflakeId;
                model.Status = StockInStatus.initial.ToByte();
                model.CreateBy = UserDtoCache.UserId;
                bool flag = _stockoutdetailServices.Insert(model);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                model.StockOutDetailId = id.ToInt64();
                model.ModifiedBy = UserDtoCache.UserId;
                model.ModifiedDate = DateTimeExt.DateTime;
                var flag = _stockoutdetailServices.Update(model);
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
            var list = _stockoutdetailServices.QueryableToList(c => c.IsDel == 1 && c.StockOutId == SqlFunc.ToInt64(id));
            if (!list.Any())
            {
                return BootJsonH((false, PubConst.StockIn4));
            }
            var flag = _stockoutServices.Auditin(UserDtoCache.UserId, SqlFunc.ToInt64(id));
            return BootJsonH(flag.IsSuccess ? (flag.IsSuccess, PubConst.StockIn2) : (flag.IsSuccess, flag.ErrorMessage));
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
                 _client.Updateable(new Wms_stockoutdetail { IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime })
                 .UpdateColumns(c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate }).Where(c => c.StockOutId == SqlFunc.ToInt64(id) && c.IsDel == 1).ExecuteCommand();

                 _client.Updateable(new Wms_stockout { StockOutId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }).UpdateColumns(c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate }).ExecuteCommand();
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
            var flag = _stockoutdetailServices.Update(
                 new Wms_stockoutdetail { IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime },
                 c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate },
                 c => c.StockOutDetailId == SqlFunc.ToInt64(id)
                 );
            return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
        }

        [HttpGet]
        public IActionResult PreviewJson(string id)
        {
            var str = _stockoutServices.PrintList(id);
            return Content(str);
        }
    }
}