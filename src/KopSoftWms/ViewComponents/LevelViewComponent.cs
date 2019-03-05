using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YL.Utils.Extensions;
using YL.Utils.Pub;

namespace KopSoftWms.ViewComponents
{
    public class LevelViewComponent : ViewComponent
    {
        public LevelViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await EnumExt.ToKVListLinq<PubLevel>().ToAsync();
            return View(list);
        }
    }
}