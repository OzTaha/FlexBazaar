using FlexBazaar.DtoLayer.CatalogDtos.FeatureDtos;

namespace FlexBazaar.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;
        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // EKLE
        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureDto>("features", createFeatureDto);
        }

        // SİL
        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync("features?id=" + id);
        }

        // Tüm kategorileri getir
        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {

            // 1. yöntem
            var responseMessage = await _httpClient.GetAsync("features");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureDto>>();

            // 2. yöntem
            //var responseMessage = await _httpClient.GetAsync("features");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureDto>>();
            return values;
        }

        // ID'ye göre getir
        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("features/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureDto>();
            return values;
        }

        // GÜNCELLE
        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("features", updateFeatureDto);
        }
    }
}
