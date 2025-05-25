using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
         
            return View();
        }
    }
}
