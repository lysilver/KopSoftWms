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
    public class SupplierController : BaseController
    {
        private readonly IWms_supplierServices _supplierServices;
        private readonly IWms_stockinServices _stockinServices;

        public SupplierController(
            IWms_stockinServices stockinServices,
            IWms_supplierServices supplierServices)
        {
            _stockinServices = stockinServices;
            _supplierServices = supplierServices;
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
            var sd = _supplierServices.PageList(bootstrap);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            var model = new Wms_supplier();
            if (id.IsEmpty())
            {
                return View(model);
            }
            else
            {
                model = _supplierServices.QueryableToEntity(c => c.SupplierId == SqlFunc.ToInt64(id));
                return View(model);
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Wms_supplier model, [FromForm]string id)
        {
            var validator = new SupplierFluent();
            var results = validator.Validate(model);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (_supplierServices.IsAny(c => c.SupplierNo == model.SupplierNo || c.SupplierName == model.SupplierName))
                {
                    return BootJsonH((false, PubConst.Supplier1));
                }
                model.SupplierId = PubId.SnowflakeId;
                model.CreateBy = UserDtoCache.UserId;
                bool flag = _supplierServices.Insert(model);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                model.SupplierId = id.ToInt64();
                model.ModifiedBy = UserDtoCache.UserId;
                model.ModifiedDate = DateTimeExt.DateTime;
                var flag = _supplierServices.Update(model);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            var isDel = _stockinServices.QueryableToEntity(c => c.SupplierId == SqlFunc.ToInt64(id));
            if (!isDel.IsNullT())
            {
                return BootJsonH((false, PubConst.Supplier2));
            }
            var flag = _supplierServices.Update(new Wms_supplier { SupplierId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
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
            var json = _supplierServices.PageList(bootstrap);
            return Content(json);
        }
    }
}