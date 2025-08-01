using FlexBazaar.WebUI.Services.Interfaces;
using FlexBazaar.WebUI.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetInboxMessageAysnc(user.Id);
            return View(values);
        }

        public async Task<IActionResult> Sendbox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetSendboxMessageAysnc(user.Id);
            return View(values);
        }
    }
}
