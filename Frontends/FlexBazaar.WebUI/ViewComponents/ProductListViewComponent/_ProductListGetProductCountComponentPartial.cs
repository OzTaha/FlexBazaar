using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListGetProductCountComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke(int productCount)
        {
            return View(productCount);
        }
    }
}
