using FlexBazaar.DtoLayer.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FlexBazaar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    // AllowAnonymous] ile test etmek amaçlı kuralları görmezden gelmesi sağlandı.
    [AllowAnonymous]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }      

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasaya";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.v0 = "Kategori İşlemleri";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:7017/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                // gelen veriyi string formatta okuyacak
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            ViewBag.v1 = "Anasaya";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Yeni Kategori Girişi";
            ViewBag.v0 = "Kategori İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();          
            // metin formatındaki değeri alıp json formatına çeviriyor (serialize)
            // gönderilen createCategoryDto parametresi ilk önce json formatına çevriliyor
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            // json formatındaki veriyi stringContent'e çeviriyor. ve hangi türde olduğu belirtiliyor
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // stringContent'i post ediliyor
            var responseMessage = await client.PostAsync("http://localhost:7017/api/Categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                // başarılı bir şekilde post edildiyse
                return RedirectToAction("Index", "Category", new {area="Admin"});
            }
            return View();
        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id) {
            // canlıya alınacağı zaman yorum satırından çıkar.
           var client = _httpClientFactory.CreateClient();
          
            var responseMessage = await client.DeleteAsync("http://localhost:7017/api/Categories?id=" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {

            ViewBag.v1 = "Anasaya";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Güncelleme Sayfası";
            ViewBag.v0 = "Kategori İşlemleri";
      
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7017/api/Categories/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {

            var client = _httpClientFactory.CreateClient();
            // metin formatındaki değeri alıp json formatına çeviriyor (serialize)
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:7017/api/Categories/", stringContent );
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}
