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
    public class DeliveryController : BaseController
    {
        private readonly IWms_deliveryServices _deliveryServices;

        public DeliveryController(
            IWms_deliveryServices deliveryServices
            )
        {
            _deliveryServices = deliveryServices;
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
            var sd = _deliveryServices.PageList(bootstrap);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult Add(string id, string stockOutId)
        {
            var model = new Wms_delivery();

            if (id.IsEmpty())
            {
                model.StockOutId = stockOutId.ToInt64();
                return View(model);
            }
            else
            {
                model = _deliveryServices.QueryableToEntity(c => c.DeliveryId == SqlFunc.ToInt64(id));
                return View(model);
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Wms_delivery model, [FromForm]string id)
        {
            var validator = new DeliveryFluent();
            var results = validator.Validate(model);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (!model.TrackingNo.IsEmpty())
                {
                    if (_deliveryServices.IsAny(c => c.TrackingNo == model.TrackingNo))
                    {
                        return BootJsonH((false, PubConst.Delivery3));
                    }
                }
                model.DeliveryId = PubId.SnowflakeId;
                model.CreateBy = UserDtoCache.UserId;
                bool flag = _deliveryServices.Delivery(model);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                model.DeliveryId = id.ToInt64();
                model.ModifiedBy = UserDtoCache.UserId;
                model.ModifiedDate = DateTimeExt.DateTime;
                var flag = _deliveryServices.Update(model);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            var flag = _deliveryServices.Update(new Wms_delivery { DeliveryId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
            return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
        }
    }
}