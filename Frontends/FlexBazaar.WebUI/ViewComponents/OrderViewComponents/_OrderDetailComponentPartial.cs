using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderDetailComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
