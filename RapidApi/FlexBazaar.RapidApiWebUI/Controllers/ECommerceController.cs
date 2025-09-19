using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.RapidApiWebUI.Controllers
{
    public class ECommerceController : Controller
    {
        public async Task<IActionResult> ECommerceList()
        {
            return View();
        }
    }
}
