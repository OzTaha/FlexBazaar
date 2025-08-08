using System.Net.Http;

namespace FlexBazaar.SignalRRealTimeApi.SignalRServices.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;
        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("UserMessages/GetTotalMessageCountByReceiverId?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
