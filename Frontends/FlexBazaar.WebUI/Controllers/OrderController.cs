using FlexBazaar.DtoLayer.OrderDtos.OrderAddressDtos;
using FlexBazaar.WebUI.Services.Interfaces;
using FlexBazaar.WebUI.Services.OrderServices.OrderAddressServices;
using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Controllers
{    
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;

        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.breadcrumb1 = "Ana sayfa";
            ViewBag.breadcrumb2 = "Siparişler";
            ViewBag.breadcrumb3 = "Sipariş İşlemleri";
            return View();
        }
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {           
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = values.Id;
            createOrderAddressDto.Description = "aa";

            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);

            return RedirectToAction("Index", "Payment");
        }
    }
}
