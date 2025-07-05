using FlexBazaar.DtoLayer.CatalogDtos.ContactDtos;
using FlexBazaar.WebUI.Services.CatalogServices.ContactServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FlexBazaar.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.breadcrumb1 = "Ana sayfa";
            ViewBag.breadcrumb2 = "İletişim";
            ViewBag.breadcrumb3 = "Mesaj Gönder";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Now;
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("Index", "Default");                      
        }
    }
}
