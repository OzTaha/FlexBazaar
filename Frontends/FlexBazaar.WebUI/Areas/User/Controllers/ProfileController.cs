using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
