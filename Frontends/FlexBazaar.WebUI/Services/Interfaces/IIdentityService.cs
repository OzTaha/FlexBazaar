using FlexBazaar.DtoLayer.IdentityDtos.LoginDtos;

namespace FlexBazaar.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
