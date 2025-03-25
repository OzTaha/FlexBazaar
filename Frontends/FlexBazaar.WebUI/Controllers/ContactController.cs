using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
