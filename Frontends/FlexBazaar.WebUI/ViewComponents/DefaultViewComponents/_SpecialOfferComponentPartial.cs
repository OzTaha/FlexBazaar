using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
