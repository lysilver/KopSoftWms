using IServices;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Linq;
using YL.Core.Entity;
using YL.Core.Entity.Fluent.Validation;
using YL.NetCore.Attributes;
using YL.NetCore.NetCoreApp;
using YL.Utils.Extensions;
using YL.Utils.Files;
using YL.Utils.Pub;
using YL.Utils.Security;
using YL.Utils.Table;

namespace KopSoftWms.Controllers
{
    public class MaterialController : BaseController
    {
        private readonly IWms_materialServices _materialServices;
        private readonly IWms_inventoryServices _inventoryServices;

        public MaterialController(IWms_materialServices materialServices,
            IWms_inventoryServices inventoryServices
            )
        {
            _materialServices = materialServices;
            _inventoryServices = inventoryServices;
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
            var sd = _materialServices.PageList(bootstrap);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            var model = new Wms_material();
            if (id.IsEmpty())
            {
                return View(model);
            }
            else
            {
                model = _materialServices.QueryableToEntity(c => c.MaterialId == SqlFunc.ToInt64(id));
                return View(model);
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Wms_material model, [FromForm]string id)
        {
            var validator = new MaterialFluent();
            var results = validator.Validate(model);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (_materialServices.IsAny(c => c.MaterialNo == model.MaterialNo || c.MaterialName == model.MaterialName))
                {
                    return BootJsonH((false, PubConst.Material1));
                }
                model.MaterialId = PubId.SnowflakeId;
                model.CreateBy = UserDtoCache.UserId;
                bool flag = _materialServices.Insert(model);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                model.MaterialId = id.ToInt64();
                model.ModifiedBy = UserDtoCache.UserId;
                model.ModifiedDate = DateTimeExt.DateTime;
                var flag = _materialServices.Update(model);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            //判断库存数量，库存数量小于等于0，才能删除
            var isExist = _inventoryServices.IsAny(c => c.MaterialId == SqlFunc.ToInt64(id));
            if (isExist)
            {
                return BootJsonH((false, PubConst.Material2));
            }
            else
            {
                var flag = _materialServices.Update(new Wms_material { MaterialId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
                return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
            }
        }

        /// <summary>
        /// 入库选择物料，默认显示100条数据，如果没有在从服务端取数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
            var json = _materialServices.PageList(bootstrap);
            return Content(json);
        }

        [HttpGet]
        [OperationLog(LogType.export)]
        public IActionResult Export([FromQuery]Bootstrap.BootstrapParams bootstrap)
        {
            var buffer = _materialServices.ExportList(bootstrap);
            if (buffer.IsNull())
            {
                return File(JsonL((false, PubConst.File8)).ToBytes(), ContentType.ContentTypeJson);
            }
            return File(buffer, ContentType.ContentTypeFile, DateTimeExt.GetDateTimeS(DateTimeExt.DateTimeFormatString) + "-" + EncoderUtil.UrlHttpUtilityEncoder("物料") + ".xlsx");
        }
    }
}