using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YL.Utils.Extensions;

namespace KopSoftWms.ViewComponents
{
    public class DeptViewComponent : ViewComponent
    {
        private readonly ISys_deptServices _deptServices;

        public DeptViewComponent(ISys_deptServices deptServices)
        {
            _deptServices = deptServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dept = await _deptServices.QueryableToList(c => c.IsDel == 1).ToListAsync();
            return View(dept);
        }
    }
}