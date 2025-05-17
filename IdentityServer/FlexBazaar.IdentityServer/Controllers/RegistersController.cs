using FlexBazaar.IdentityServer.Dtos;
using FlexBazaar.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace FlexBazaar.IdentityServer.Controllers
{
    [AllowAnonymous]
    //[Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                SurName = userRegisterDto.Surname
            };
            var result = await _userManager.CreateAsync(values, userRegisterDto.Password);
            if (result.Succeeded) {
                return Ok("Kullanıcı başarıyla eklendi.");
            } 
            else
            {
                return Ok("Bir hata oluştu tekrar deneyin.");
               // var errors = string.Join(", ", result.Errors.Select(x => x.Description));
               //return BadRequest($"Bir hata oluştu: {errors}");
            }
        }
    }
}
