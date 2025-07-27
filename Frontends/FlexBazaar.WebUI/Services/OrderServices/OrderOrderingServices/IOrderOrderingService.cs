using FlexBazaar.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace FlexBazaar.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string userId);
    }
}
