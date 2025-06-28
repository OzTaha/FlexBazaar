using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _BreadcrumbUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }    
}
