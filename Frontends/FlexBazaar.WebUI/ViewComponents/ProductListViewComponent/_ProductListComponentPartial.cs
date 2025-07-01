using FlexBazaar.DtoLayer.CatalogDtos.ProductDtos;
using FlexBazaar.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlexBazaar.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListComponentPartial : ViewComponent
    {
        //public IViewComponentResult Invoke(int productCount)
        //{
        //    return View(productCount);
        //}
        private readonly IProductService _productService;

        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
            return View(values);

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://localhost:7017/api/Products/ProductListWithCategoryByCategoryId?id="+id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //    return View(values);
            //}
            //return View();
        }
    }
}
