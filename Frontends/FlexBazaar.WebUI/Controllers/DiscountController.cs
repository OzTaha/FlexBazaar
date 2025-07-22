using FlexBazaar.WebUI.Services.BasketServices;
using FlexBazaar.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;
        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var values = await _discountService.GetDiscountCouponCountRate(code);
           
            // ViewBag.newTotalPriceWithDiscount = newTotalPriceWithDiscount;

            // Geçerli kupon kodu, indirimi uygula
            var basketValues = await _basketService.GetBasket();
            var totalPriceWithTax = basketValues.TotalPrice + (basketValues.TotalPrice / 100 * 10); // 10% vergi eklenmiş toplam tutar
            var newTotalPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * values);

            return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = values, newTotalPriceWithDiscount = newTotalPriceWithDiscount });
        }
    }
}