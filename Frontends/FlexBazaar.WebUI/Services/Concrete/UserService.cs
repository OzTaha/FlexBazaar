using FlexBazaar.WebUI.Models;
using FlexBazaar.WebUI.Services.Interfaces;

namespace FlexBazaar.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            // kullanıcının bilgilerini getirecek olan metod (getuser)
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
        }
    }
}
