using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.breadcrumb1 = "Ana sayfa";
            ViewBag.breadcrumb2 = "Siparişler";
            ViewBag.breadcrumb3 = "Sipariş İşlemleri";
            return View();
        }
    }
}
