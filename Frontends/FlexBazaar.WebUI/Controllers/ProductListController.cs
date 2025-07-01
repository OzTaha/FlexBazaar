using FlexBazaar.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FlexBazaar.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(string id)
        {
            ViewBag.breadcrumb1 = "Ana sayfa";
            ViewBag.breadcrumb2 = "Ürünler";
            ViewBag.breadcrumb3 = "Ürün Listesi";
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.breadcrumb1 = "Ana sayfa";
            ViewBag.breadcrumb2 = "Ürünler Listesi";
            ViewBag.breadcrumb3 = "Ürün Detayları";
            ViewBag.x = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {          
            return PartialView();
        }

        [HttpPost]
        public async Task< IActionResult>  AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "test";
            createCommentDto.Rating = 1;
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Status = false;
            createCommentDto.ProductId = "67f879fc01493b235fc46eb2";
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:7263/api/Comments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
