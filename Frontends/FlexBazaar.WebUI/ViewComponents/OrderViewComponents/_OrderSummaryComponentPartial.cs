using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
