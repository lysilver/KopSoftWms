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

namespace KopSoftWms.Controllers
{
    public class DictController : BaseController
    {
        private readonly ISys_dictServices _dictServices;

        public DictController(ISys_dictServices dictServices)
        {
            _dictServices = dictServices;
        }

        [HttpGet]
        [CheckMenu]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [OperationLog(LogType.select)]
        public ContentResult List([FromForm]PubParams.DictBootstrapParams bootstrap)
        {
            var sd = _dictServices.PageList(bootstrap);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            var model = new Sys_dict();
            if (id.IsEmpty())
            {
                return View(model);
            }
            else
            {
                model = _dictServices.QueryableToEntity(c => c.DictId == SqlFunc.ToInt64(id));
                return View(model);
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Sys_dict dict, [FromForm]string id)
        {
            var validator = new SysDictFluent();
            var results = validator.Validate(dict);
            var success = results.IsValid;
            if (!success)
            {
                //string msg = results.Errors.Aggregate("", (current, item) => current + (item.ErrorMessage + "</br>"));
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (_dictServices.IsAny(c => c.DictName == dict.DictName))
                {
                    return BootJsonH((false, PubConst.Dict1));
                }
                dict.DictId = PubId.SnowflakeId;
                dict.CreateBy = UserDtoCache.UserId;
                bool flag = _dictServices.Insert(dict);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                dict.DictId = id.ToInt64();
                dict.ModifiedBy = UserDtoCache.UserId;
                dict.ModifiedDate = DateTimeExt.DateTime;
                var flag = _dictServices.Update(dict);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            var flag = _dictServices.Update(new Sys_dict { DictId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
            return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
        }
    }
}