using FlexBazaar.DtoLayer.CommentDtos;
using FlexBazaar.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace FlexBazaar.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;
        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
        {
            //var resposeMessage = await _httpClient.GetAsync("orders/GetOrderingByUserId?id=" + id);
            //var values = await resposeMessage.Content.ReadFromJsonAsync<ResultOrderingByUserIdDto>();
            //return values;
            var responseMessage = await _httpClient.GetAsync($"orderings/GetOrderingByUserId/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingByUserIdDto>>();
            return values;
        }
    }
}
