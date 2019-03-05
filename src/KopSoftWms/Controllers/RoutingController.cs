using Microsoft.AspNetCore.Mvc;

namespace KopSoftWms.Controllers
{
    public class RoutingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}