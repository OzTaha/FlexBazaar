using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.ViewComponents.ContactViewComponents
{
    public class _ContactDetailComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
