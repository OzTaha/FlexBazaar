using FlexBazaar.DtoLayer.CatalogDtos.SpecialOfferDtos;
using FlexBazaar.WebUI.Services.CatalogServices.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FlexBazaar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    // AllowAnonymous] ile test etmek amaçlı kuralları görmezden gelmesi sağlandı.
    [AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        void SpecialOfferViewbagList()
        {
            ViewBag.v1 = "Anasaya";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif ve Günün İndirimi Listesi";
            ViewBag.v0 = "Kategori İşlemleri";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            SpecialOfferViewbagList();

            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }


        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            SpecialOfferViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferViewbagList();

            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(values);
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}
