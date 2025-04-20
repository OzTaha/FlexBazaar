using FlexBazaar.DtoLayer.CatalogDtos.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FlexBazaar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    // AllowAnonymous] ile test etmek amaçlı kuralları görmezden gelmesi sağlandı.
    [AllowAnonymous]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasaya";
            ViewBag.v2 = "Öne Çıkan Alanlar";
            ViewBag.v3 = "Öne Çıkan Alanlar Listesi";
            ViewBag.v0 = "Anasayfa Öne Çıkan Alan İşlemleri";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:7017/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                // gelen veriyi string formatta okuyacak
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            ViewBag.v1 = "Anasaya";
            ViewBag.v2 = "Öne Çıkan Alanlar";
            ViewBag.v3 = "Öne Çıkan Alanlar Listesi";
            ViewBag.v0 = "Anasayfa Öne Çıkan Alan İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:7017/api/Features", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("http://localhost:7017/api/Features?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {

            ViewBag.v1 = "Anasaya";
            ViewBag.v2 = "Öne Çıkan Alanlar";
            ViewBag.v3 = "Öne Çıkan Alanlar Listesi";
            ViewBag.v0 = "Anasayfa Öne Çıkan Alan İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7017/api/Features/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:7017/api/Features/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
    }
}
