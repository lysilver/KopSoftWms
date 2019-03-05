using IServices;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
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
    public class DeviceController : BaseController
    {
        private readonly IWms_deviceServices _deviceServices;
        private readonly ISys_deptServices _deptServices;
        private readonly ISys_dictServices _dictServices;

        public DeviceController(ISys_dictServices dictServices, ISys_deptServices deptServices, IWms_deviceServices deviceServices)
        {
            _dictServices = dictServices;
            _deviceServices = deviceServices;
            _deptServices = deptServices;
        }

        [HttpGet]
        [CheckMenu]
        public IActionResult Index()
        {
            ViewBag.Dept = _deptServices.QueryableToList(c => c.IsDel == 1);
            ViewBag.Device = _dictServices.Queryable().Where(c => c.IsDel == 1 && c.DictType == SqlFunc.ToString(Convert.ToInt32(PubDictType.device))).ToList();
            ViewBag.Property = _dictServices.Queryable().Where(c => c.IsDel == 1 && c.DictType == SqlFunc.ToString(Convert.ToInt32(PubDictType.property))).ToList(); ;
            return View();
        }

        [HttpPost]
        [OperationLog(LogType.select)]
        public ContentResult List([FromForm]PubParams.DeviceBootstrapParams bootstrap)
        {
            var sd = _deviceServices.PageList(bootstrap);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            var model = new Wms_device();
            if (id.IsEmpty())
            {
                return View(model);
            }
            else
            {
                model = _deviceServices.QueryableToEntity(c => c.DeviceId == SqlFunc.ToInt64(id));
                return View(model);
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Wms_device device, [FromForm]string id)
        {
            var validator = new DeviceFluent();
            var results = validator.Validate(device);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (current + item.ErrorMessage + "</br>"));
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (_deviceServices.IsAny(c => c.SerialNo == device.SerialNo))
                {
                    return BootJsonH((false, PubConst.Device1));
                }
                device.DeviceId = PubId.SnowflakeId;
                device.CreateBy = UserDtoCache.UserId;
                bool flag = _deviceServices.Insert(device);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                device.DeviceId = id.ToInt64();
                device.ModifiedBy = UserDtoCache.UserId;
                device.ModifiedDate = DateTimeExt.DateTime;
                var flag = _deviceServices.Update(device);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            var flag = _deviceServices.Update(new Wms_device { DeviceId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
            return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
        }
    }
}