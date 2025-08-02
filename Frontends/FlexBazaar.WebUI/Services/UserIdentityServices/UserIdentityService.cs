using FlexBazaar.DtoLayer.IdentityDtos.UserDtos;

namespace FlexBazaar.WebUI.Services.UserIdentityServices
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;
        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultUserDto>> GetAllUserListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/api/users/GetAllUserList");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultUserDto>>();
            return values;
        }
    }
}
