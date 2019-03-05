using IServices;
using Microsoft.AspNetCore.Mvc;
using YL.Core.Dto;
using YL.NetCore.Attributes;
using YL.NetCore.NetCoreApp;
using YL.Utils.Pub;

namespace KopSoftWms.Controllers
{
    public class InventoryRecordController : BaseController
    {
        private readonly IWms_inventoryrecordServices _inventoryrecordServices;

        public InventoryRecordController(
            IWms_inventoryrecordServices inventoryrecordServices
            )
        {
            _inventoryrecordServices = inventoryrecordServices;
        }

        [HttpGet]
        [CheckMenu]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [OperationLog(LogType.select)]
        public ContentResult List([FromForm]PubParams.InventoryBootstrapParams bootstrap)
        {
            var sd = _inventoryrecordServices.PageList(bootstrap);
            return Content(sd);
        }
    }
}