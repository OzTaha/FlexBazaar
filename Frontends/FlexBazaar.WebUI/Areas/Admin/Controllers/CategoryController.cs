using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
