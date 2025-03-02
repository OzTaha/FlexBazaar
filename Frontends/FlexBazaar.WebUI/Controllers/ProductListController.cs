using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
