using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return View();
        }
    }
}
