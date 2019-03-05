using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.IO;
using System.Linq;
using YL.Core.Entity;
using YL.Core.Entity.Fluent.Validation;
using YL.NetCore.Attributes;
using YL.NetCore.NetCoreApp;
using YL.Utils.Delegate;
using YL.Utils.Excel;
using YL.Utils.Extensions;
using YL.Utils.Files;
using YL.Utils.Json;
using YL.Utils.Pub;
using YL.Utils.Table;

namespace KopSoftWms.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IWms_CustomerServices _customerServices;

        public CustomerController(IWms_CustomerServices customerServices)
        {
            _customerServices = customerServices;
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
            var sd = _customerServices.PageList(bootstrap);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            var model = new Wms_Customer();
            if (id.IsEmpty())
            {
                return View(model);
            }
            else
            {
                model = _customerServices.QueryableToEntity(c => c.CustomerId == SqlFunc.ToInt64(id));
                return View(model);
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Wms_Customer model, [FromForm]string id)
        {
            var validator = new CustomerFluent();
            var results = validator.Validate(model);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (_customerServices.IsAny(c => c.CustomerNo == model.CustomerNo || c.CustomerName == model.CustomerName))
                {
                    return BootJsonH((false, PubConst.Customer1));
                }
                model.CustomerId = PubId.SnowflakeId;
                model.CreateBy = UserDtoCache.UserId;
                bool flag = _customerServices.Insert(model);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                model.CustomerId = id.ToInt64();
                model.ModifiedBy = UserDtoCache.UserId;
                model.ModifiedDate = DateTimeExt.DateTime;
                var flag = _customerServices.Update(model);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            var flag = _customerServices.Update(new Wms_Customer { CustomerId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
            return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
        }

        [HttpGet]
        public IActionResult Download()
        {
            var stream = System.IO.File.OpenRead(Path.Combine(WebRoot, "excel", "customer.xlsx"));
            return File(stream, ContentType.ContentTypeExcel, "customer.xlsx");
        }

        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImportExcel(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BootJsonH((false, PubConst.File1));
            }
            string fileExt = Path.GetExtension(file.FileName).ToLower();
            if (!NpoiUtil.excel.Contains(fileExt))
            {
                return BootJsonH((false, PubConst.File2));
            }
            var filepath = Path.Combine(WebRoot, "upload", PubId.GetUuid()) + fileExt;
            //1 直接通过流
            return DelegateUtil.TryExecute<IActionResult>(() =>
             {
                 using (var st = new MemoryStream())
                 {
                     file.CopyTo(st);
                     var dt = NpoiUtil.Import(st, fileExt);
                     var json = _customerServices.Import(dt, UserDtoCache.UserId).JilToJson();
                     return Content(json);
                 }
             }, BootJsonH((false, PubConst.File3))
             );
            //using (var st = new MemoryStream())
            //{
            //    file.CopyTo(st);
            //    var dt = NpoiUtil.Import(st, fileExt);
            //    var json = _customerServices.Import(dt, UserDtoCache.UserId).JilToJson();
            //    return Content(json);
            //}
            //2 先上传到服务器，然后在读取
            //using (var stream = new FileStream(filepath, FileMode.CreateNew))
            //{
            //    file.CopyTo(stream);
            //}
            //var dt = NpoiUtil.Import(filepath);
            //FileUtil.Delete(filepath);
            //var json = _customerServices.Import(dt, UserDtoCache.UserId).JilToJson();
            //return Content(json);
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
    }
}