using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YL.Utils.Extensions;
using YL.Utils.Pub;

namespace KopSoftWms.ViewComponents
{
    public class DictTypeSViewComponent : ViewComponent
    {
        public DictTypeSViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await EnumExt.ToKVListLinq<PubDictType>().ToAsync();
            return View(list);
        }
    }
}