using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {         
            ViewBag.breadcrumb1 = "Ana sayfa";
            ViewBag.breadcrumb3 = "Ürün Listesi";
            return View();
        }
    }
}
