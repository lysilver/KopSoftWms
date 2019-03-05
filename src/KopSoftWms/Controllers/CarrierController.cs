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
    public class CarrierController : BaseController
    {
        private readonly IWms_CarrierServices _carrierServices;

        public CarrierController(IWms_CarrierServices carrierServices)
        {
            _carrierServices = carrierServices;
        }

        [HttpGet]
        [CheckMenu]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [OperationLog(LogType = LogType.select)]
        public ContentResult List([FromForm]Bootstrap.BootstrapParams bootstrap)
        {
            var sd = _carrierServices.PageList(bootstrap);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            var model = new Wms_Carrier();
            if (id.IsEmpty())
            {
                return View(model);
            }
            else
            {
                model = _carrierServices.QueryableToEntity(c => c.CarrierId == SqlFunc.ToInt64(id));
                return View(model);
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType = LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Wms_Carrier model, [FromForm]string id)
        {
            var validator = new CarrierFluent();
            var results = validator.Validate(model);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (_carrierServices.IsAny(c => c.CarrierNo == model.CarrierNo || c.CarrierName == model.CarrierName))
                {
                    return BootJsonH((false, PubConst.Carrier1));
                }
                model.CarrierId = PubId.SnowflakeId;
                model.CreateBy = UserDtoCache.UserId;
                bool flag = _carrierServices.Insert(model);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                model.CarrierId = id.ToInt64();
                model.ModifiedBy = UserDtoCache.UserId;
                model.ModifiedDate = DateTimeExt.DateTime;
                var flag = _carrierServices.Update(model);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType = LogType.delete)]
        public IActionResult Delete(string id)
        {
            var flag = _carrierServices.Update(new Wms_Carrier { CarrierId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
            return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
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
            var json = _carrierServices.PageList(bootstrap);
            return Content(json);
        }
    }
}