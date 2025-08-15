using Newtonsoft.Json;

namespace FlexBazaar.SignalRRealTimeApi.SignalRServices.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SignalRCommentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<int> GetTotalCommentCount()
        {
           var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7022/api/CommentStatistics");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var commentCount = JsonConvert.DeserializeObject<int>(jsonData);
            return commentCount;
        }      
    }
}
