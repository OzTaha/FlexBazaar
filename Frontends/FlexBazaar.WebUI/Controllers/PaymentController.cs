using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.breadcrumb1 = "Anasayfa";
            ViewBag.breadcrumb2 = "Ödeme Ekranı";
            ViewBag.breadcrumb3 = "Kartla Ödeme";
            return View();
        }
    }
}
