using FlexBazaar.DtoLayer.CatalogDtos.BrandDtos;
using FlexBazaar.WebUI.Services.CatalogServices.BrandServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlexBazaar.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
       private readonly IBrandService _brandService;

        public _VendorDefaultComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.GetAllBrandAsync();
            if (values != null && values.Count > 0)
            {
                return View(values);
            }
            else
            {
                // Eğer değerler boşsa, boş bir liste döndür
                return View(new List<ResultBrandDto>());
            }
        }
    }
}
