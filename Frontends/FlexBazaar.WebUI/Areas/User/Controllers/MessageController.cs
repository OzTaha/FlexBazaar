using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Areas.User.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
