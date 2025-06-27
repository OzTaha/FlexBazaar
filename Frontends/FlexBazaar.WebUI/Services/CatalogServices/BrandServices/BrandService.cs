using FlexBazaar.DtoLayer.CatalogDtos.BrandDtos;

namespace FlexBazaar.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;
        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // EKLE
        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDto>("brands", createBrandDto);
        }

        // SİL
        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync("brands?id=" + id);
        }

        // Tüm markaları getir
        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {

            // 1. yöntem
            var responseMessage = await _httpClient.GetAsync("brands");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultBrandDto>>();

            // 2. yöntem
            //var responseMessage = await _httpClient.GetAsync("brands");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultBrandDto>>();
            return values;
        }

        // ID'ye göre markaları getir
        public async Task<UpdateBrandDto> GetByIdBrandAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("brands/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateBrandDto>();
            return values;
        }

        // GÜNCELLE
        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDto>("brands", updateBrandDto);
        }
    }
}
