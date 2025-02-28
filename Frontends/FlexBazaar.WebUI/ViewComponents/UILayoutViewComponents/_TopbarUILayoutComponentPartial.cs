using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopbarUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
