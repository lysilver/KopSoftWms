using IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YL.Utils.Extensions;
using YL.Utils.Pub;

namespace KopSoftWms.ViewComponents
{
    public class DictViewComponent : ViewComponent
    {
        private readonly ISys_dictServices _dictServices;

        public DictViewComponent(ISys_dictServices dictServices)
        {
            _dictServices = dictServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string type)
        {
            var d = EnumExt.GetDescription<PubDictType>(type);
            var value = 0;
            var obj = type.ToEnum<PubDictType>();
            switch (obj)
            {
                case PubDictType.unit:
                    value = Convert.ToInt32(PubDictType.unit);
                    ViewData["field"] = "Unit";
                    break;

                case PubDictType.material:
                    value = Convert.ToInt32(PubDictType.material);
                    ViewData["field"] = "MaterialType";
                    break;

                case PubDictType.stockin:
                    value = Convert.ToInt32(PubDictType.stockin);
                    ViewData["field"] = "StockinType";
                    break;

                case PubDictType.stockout:
                    value = Convert.ToInt32(PubDictType.stockout);
                    ViewData["field"] = "StockoutType";
                    break;

                case PubDictType.device:
                    value = Convert.ToInt32(PubDictType.device);
                    ViewData["field"] = "DeviceType";
                    break;

                case PubDictType.property:
                    value = Convert.ToInt32(PubDictType.property);
                    ViewData["field"] = "PropertyType";
                    break;

                default:
                    break;
            }
            var list = await _dictServices.Queryable().Where(c => c.IsDel == 1 && c.DictType == SqlSugar.SqlFunc.ToString(value))
               .ToListAsync();
            ViewData["type"] = d;
            return View(list);
        }
    }
}