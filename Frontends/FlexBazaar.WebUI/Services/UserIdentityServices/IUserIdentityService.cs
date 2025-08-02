using FlexBazaar.DtoLayer.IdentityDtos.UserDtos;

namespace FlexBazaar.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService 
    {
        Task<List<ResultUserDto>> GetAllUserListAsync();
    }
}
