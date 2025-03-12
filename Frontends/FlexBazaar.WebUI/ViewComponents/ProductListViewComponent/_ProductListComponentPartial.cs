using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke(int productCount)
        {
            return View(productCount);
        }
    }
}
