using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Areas.User.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
