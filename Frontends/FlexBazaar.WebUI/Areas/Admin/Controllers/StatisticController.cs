using FlexBazaar.WebUI.Services.CommentServices;
using FlexBazaar.WebUI.Services.StatisticServices.CatalogStatisticServices;
using FlexBazaar.WebUI.Services.StatisticServices.DiscountStatisticServices;
using FlexBazaar.WebUI.Services.StatisticServices.MessageStatisticServices;
using FlexBazaar.WebUI.Services.StatisticServices.UserStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentService _commentService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentService commentService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentService = commentService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            // Catalog istatistikleri
            var getBrandCount = await _catalogStatisticService.GetBrandCount();
            var getProductCount = await _catalogStatisticService.GetProductCount();
            var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
            var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            var getProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();

            // User istatistikleri
            var getUserCount = await _userStatisticService.GetUserCount();

            // Comment istatistikleri
            var getTotalCommentCount = await _commentService.GetTotalCommentCount();
            var getActiveCommentCount = await _commentService.GetActiveCommentCount();
            var getPassiveCommentCount = await _commentService.GetPassiveCommentCount();

            // Discount istatistikleri
            var getDiscountCouponCount = await _discountStatisticService.GetDiscountCouponCount();

            // Message istatistikleri
            var getTotalMessageCount = await _messageStatisticService.GetTotalMessageCount();

            // ViewBag üzerinden catalog verileri View'a gönderiliyor
            ViewBag.getBrandCount = getBrandCount;
            ViewBag.getProductCount = getProductCount;
            ViewBag.getCategoryCount = getCategoryCount;
            ViewBag.getMaxPriceProductName = getMaxPriceProductName;
            ViewBag.getMinPriceProductName = getMinPriceProductName;
            ViewBag.getProductAvgPrice = getProductAvgPrice;

            // ViewBag üzerinden user verileri View'a gönderiliyor
            ViewBag.getUserCount = getUserCount;

            // ViewBag üzerinden comment verileri View'a gönderiliyor
            ViewBag.getTotalCommentCount = getTotalCommentCount;
            ViewBag.getActiveCommentCount = getActiveCommentCount;
            ViewBag.getPassiveCommentCount = getPassiveCommentCount;

            // ViewBag üzerinden discount verileri View'a gönderiliyor
            ViewBag.getDiscountCouponCount = getDiscountCouponCount;

            // ViewBag üzerinden message verileri View'a gönderiliyor
            ViewBag.getTotalMessageCount = getTotalMessageCount;

            return View();
        }
    }
}
