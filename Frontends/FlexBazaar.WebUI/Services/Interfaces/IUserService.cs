using FlexBazaar.WebUI.Models;

namespace FlexBazaar.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
