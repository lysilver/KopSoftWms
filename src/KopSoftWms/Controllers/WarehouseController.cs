using IServices;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Linq;
using YL.Core.Entity;
using YL.Core.Entity.Fluent.Validation;
using YL.NetCore.Attributes;
using YL.NetCore.NetCoreApp;
using YL.Utils.Extensions;
using YL.Utils.Pub;
using YL.Utils.Table;

namespace KopSoftWms.Controllers
{
    public class WarehouseController : BaseController
    {
        private readonly IWms_warehouseServices _warehouseServices;
        private readonly IWms_reservoirareaServices _reservoirareaServices;

        public WarehouseController(IWms_reservoirareaServices reservoirareaServices, IWms_warehouseServices warehouseServices)
        {
            _reservoirareaServices = reservoirareaServices;
            _warehouseServices = warehouseServices;
        }

        [HttpGet]
        [CheckMenu]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [OperationLog(LogType.select)]
        public ContentResult List([FromForm]Bootstrap.BootstrapParams bootstrap)
        {
            var sd = _warehouseServices.PageList(bootstrap);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            var model = new Wms_warehouse();
            if (id.IsEmpty())
            {
                return View(model);
            }
            else
            {
                model = _warehouseServices.QueryableToEntity(c => c.WarehouseId == SqlFunc.ToInt64(id));
                return View(model);
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Wms_warehouse model, [FromForm]string id)
        {
            var validator = new WarehouseFluent();
            var results = validator.Validate(model);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (_warehouseServices.IsAny(c => c.WarehouseNo == model.WarehouseNo || c.WarehouseName == model.WarehouseName))
                {
                    return BootJsonH((false, PubConst.Warehouse1));
                }
                model.WarehouseId = PubId.SnowflakeId;
                model.CreateBy = UserDtoCache.UserId;
                bool flag = _warehouseServices.Insert(model);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                model.WarehouseId = id.ToInt64();
                model.ModifiedBy = UserDtoCache.UserId;
                model.ModifiedDate = DateTimeExt.DateTime;
                var flag = _warehouseServices.Update(model);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            var isExist = _reservoirareaServices.IsAny(c => c.WarehouseId == SqlFunc.ToInt64(id));
            if (isExist)
            {
                return BootJsonH((false, PubConst.Warehouse2));
            }
            else
            {
                var flag = _warehouseServices.Update(new Wms_warehouse { WarehouseId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
                return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
            }
        }
    }
}