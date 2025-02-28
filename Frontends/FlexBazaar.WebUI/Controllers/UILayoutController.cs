using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        // kullanıcı layout'u
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
