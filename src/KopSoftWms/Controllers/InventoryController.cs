using IServices;
using Microsoft.AspNetCore.Mvc;
using YL.Core.Dto;
using YL.NetCore.NetCoreApp;
using YL.NetCore.Attributes;
using YL.Utils.Pub;

namespace KopSoftWms.Controllers
{
    public class InventoryController : BaseController
    {
        private readonly IWms_inventoryServices _inventoryServices;
        private readonly IWms_storagerackServices _storagerackServices;

        public InventoryController(
            IWms_storagerackServices storagerackServices,
            IWms_inventoryServices inventoryServices
            )
        {
            _storagerackServices = storagerackServices;
            _inventoryServices = inventoryServices;
        }

        [HttpGet]
        [CheckMenu]
        public IActionResult Index()
        {
            ViewBag.StorageRack = _storagerackServices.QueryableToList(c => c.IsDel == 1);
            return View();
        }

        [HttpPost]
        [OperationLog(LogType.select)]
        public ContentResult List([FromForm]PubParams.InventoryBootstrapParams bootstrap)
        {
            var sd = _inventoryServices.PageList(bootstrap);
            return Content(sd);
        }
    }
}