using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
