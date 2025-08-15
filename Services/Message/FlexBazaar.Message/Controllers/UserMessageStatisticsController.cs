using FlexBazaar.Message.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlexBazaar.Message.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageStatisticsController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageStatisticsController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            int messageCount = await _userMessageService.GetTotalMessageCount();
            return Ok(messageCount);
        }
    }
}
