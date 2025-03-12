using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListPaginationComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke( )
        {
            return View();
        }
    }
}
