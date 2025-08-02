using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Areas.Admin.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult CargoList()
        {
            return View();
        }
    }
}
