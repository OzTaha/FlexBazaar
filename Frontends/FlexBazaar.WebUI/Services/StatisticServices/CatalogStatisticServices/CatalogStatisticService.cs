
namespace FlexBazaar.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;
        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<long> GetBrandCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetBrandCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<long> GetCategoryCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetCategoryCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMaxPriceProductName");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMinPriceProductName");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetProductAvgPrice");
            var values = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return values;
        }

        public async Task<long> GetProductCount()
        {
             var responseMessage = await _httpClient.GetAsync("statistics/GetProductCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }
    }
}
