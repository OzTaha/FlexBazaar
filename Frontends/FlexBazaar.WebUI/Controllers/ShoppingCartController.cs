using FlexBazaar.DtoLayer.BasketDtos;
using FlexBazaar.WebUI.Services.BasketServices;
using FlexBazaar.WebUI.Services.CatalogServices.ProductServices;
using FlexBazaar.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }
        public async Task<IActionResult> Index(string code, int discountRate, decimal newTotalPriceWithDiscount)
        {
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.newTotalPriceWithDiscount = newTotalPriceWithDiscount;
            ViewBag.breadcrumb1 = "Ana sayfa";
            ViewBag.breadcrumb2 = "Ürünler";
            ViewBag.breadcrumb3 = "Sepetim";
            // Sepet verilerini çek
            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;
            var totalPriceWithTax = values.TotalPrice + (values.TotalPrice / 100 * 10); // 10% vergi dahil toplam fiyat
            var tax = values.TotalPrice / 100 * 10;
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            ViewBag.tax = tax;
            // Eğer kupon kodu geçerliyse, yeni fiyatı göster
            if (discountRate > 0)
            {
                ViewBag.newTotalPriceWithDiscount = newTotalPriceWithDiscount;
            }
            else
            {
                ViewBag.newTotalPriceWithDiscount = totalPriceWithTax; // Kupon uygulanmadıysa, vergi eklenmiş toplam fiyat
            }
            return View();
        }
        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}