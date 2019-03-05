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
    public class DeptController : BaseController
    {
        private readonly ISys_deptServices _deptServices;

        public DeptController(ISys_deptServices deptServices)
        {
            _deptServices = deptServices;
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
            var sd = _deptServices.PageList(bootstrap);
            return Content(sd);
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            Sys_dept dept = new Sys_dept();
            if (id.IsEmpty())
            {
                return View(dept);
            }
            else
            {
                dept = _deptServices.QueryableToEntity(c => c.DeptId == SqlFunc.ToInt64(id));
                return View(dept);
            }
        }

        [HttpPost]
        [FilterXss]
        [OperationLog(LogType = LogType.addOrUpdate)]
        public IActionResult AddOrUpdate([FromForm]Sys_dept dept, [FromForm]string id)
        {
            var validator = new SysDeptFluent();
            var results = validator.Validate(dept);
            var success = results.IsValid;
            if (!success)
            {
                string msg = results.Errors.Aggregate("", (current, item) => (item.ErrorMessage + "</br>"));
                //foreach (var item in results.Errors)
                //{
                //    msg += item.ErrorMessage + "</br>";
                //}
                return BootJsonH((PubEnum.Failed.ToInt32(), msg));
            }
            if (id.IsEmptyZero())
            {
                if (_deptServices.IsAny(c => c.DeptNo == dept.DeptNo))
                {
                    return BootJsonH((false, PubConst.Dept2));
                }
                dept.DeptId = PubId.SnowflakeId;
                dept.CreateBy = UserDtoCache.UserId;
                bool flag = _deptServices.Insert(dept);
                return BootJsonH(flag ? (flag, PubConst.Add1) : (flag, PubConst.Add2));
            }
            else
            {
                dept.DeptId = id.ToInt64();
                dept.ModifiedBy = UserDtoCache.UserId;
                dept.ModifiedDate = DateTimeExt.DateTime;
                var flag = _deptServices.Update(dept);
                return BootJsonH(flag ? (flag, PubConst.Update1) : (flag, PubConst.Update2));
            }
        }

        [HttpGet]
        [OperationLog(LogType.delete)]
        public IActionResult Delete(string id)
        {
            //var flag = _deptServices.Delete(c => c.DeptId == SqlFunc.ToInt64(id));
            var flag = _deptServices.Update(new Sys_dept { DeptId = SqlFunc.ToInt64(id), IsDel = 0, ModifiedBy = UserDtoCache.UserId, ModifiedDate = DateTimeExt.DateTime }, c => new { c.IsDel, c.ModifiedBy, c.ModifiedDate });
            return BootJsonH(flag ? (flag, PubConst.Delete1) : (flag, PubConst.Delete2));
        }
    }
}