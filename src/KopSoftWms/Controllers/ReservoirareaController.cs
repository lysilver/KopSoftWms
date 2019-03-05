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
    public class ReservoirareaController : BaseController
    {
        private readonly IWms_reservoirareaServices _reservoirareaServices;
        private readonly IWms_storagerackServices _storagerackServices;

        public ReservoirareaController(IWms_storagerackServices storagerackServices,
            IWms_reservoirareaServices reservoirareaServices)
        {
            _storagerackServices = storagerackServices;
            _reservoirareaServices = reservoirareaServices;
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
            var sd = _reservoirareaServices.PageList(bootstrap);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            var model = new Wms_reservoirarea();
            if (id.IsEmpty())
            {
                return View(model);
            }
            else
            {
                model = _reservoirareaServices.QueryableToEntity(c => c.ReservoirAreaId == SqlFunc.ToInt64(id));
                return View(model);
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Wms_reservoirarea model, [FromForm]string id)
        {
            var validator = new ReservoirareaFluent();
            var results = validator.Validate(model);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (_reservoirareaServices.IsAny(c => c.ReservoirAreaNo == model.ReservoirAreaNo || c.ReservoirAreaName == model.ReservoirAreaName))
                {
                    return BootJsonH((false, PubConst.Warehouse4));
                }
                model.ReservoirAreaId = PubId.SnowflakeId;
                model.CreateBy = UserDtoCache.UserId;
                bool flag = _reservoirareaServices.Insert(model);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                model.ReservoirAreaId = id.ToInt64();
                model.ModifiedBy = UserDtoCache.UserId;
                model.ModifiedDate = DateTimeExt.DateTime;
                var flag = _reservoirareaServices.Update(model);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            var isExist = _storagerackServices.IsAny(c => c.ReservoirAreaId == SqlFunc.ToInt64(id));
            if (isExist)
            {
                return BootJsonH((false, PubConst.Warehouse3));
            }
            else
            {
                var flag = _reservoirareaServices.Update(new Wms_reservoirarea { ReservoirAreaId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
                return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
            }
        }
    }
}