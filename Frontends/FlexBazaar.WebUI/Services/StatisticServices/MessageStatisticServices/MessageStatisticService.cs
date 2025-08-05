
namespace FlexBazaar.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public class MessageStatisticService : IMessageStatisticService
    {
        private readonly HttpClient _httpClient;
        public MessageStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetTotalMessageCount()
        {
            var responseMessage = await _httpClient.GetAsync("UserMessages/GetTotalMessageCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
