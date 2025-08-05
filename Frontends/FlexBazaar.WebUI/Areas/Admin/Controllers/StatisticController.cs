using FlexBazaar.WebUI.Services.StatisticServices.CatalogStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        public StatisticController(ICatalogStatisticService catalogStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            // İstatistik verilerini çekiyoruz
            var getBrandCount = await _catalogStatisticService.GetBrandCount();
            var getProductCount = await _catalogStatisticService.GetProductCount();
            var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
            var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            var getProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();

            // ViewBag üzerinden verileri View'a gönderiyoruz
            ViewBag.getBrandCount = getBrandCount;
            ViewBag.getProductCount = getProductCount;
            ViewBag.getCategoryCount = getCategoryCount;
            ViewBag.getMaxPriceProductName = getMaxPriceProductName;
            ViewBag.getMinPriceProductName = getMinPriceProductName;
            ViewBag.getProductAvgPrice = getProductAvgPrice;
            return View();
        }
    }
}
