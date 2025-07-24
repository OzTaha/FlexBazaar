using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.ViewComponents.OrderViewComponents
{
    public class _PaymentMethodComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
