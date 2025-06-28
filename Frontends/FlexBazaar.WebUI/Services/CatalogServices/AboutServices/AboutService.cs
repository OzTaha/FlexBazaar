using FlexBazaar.DtoLayer.CatalogDtos.AboutDtos;

namespace FlexBazaar.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;
        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // EKLE
        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDto>("abouts", createAboutDto);
        }

        // SİL
        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("abouts?id=" + id);
        }

        // Tüm kategorileri getir
        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {

            // 1. yöntem
            var responseMessage = await _httpClient.GetAsync("abouts");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultAboutDto>>();

            // 2. yöntem
            //var responseMessage = await _httpClient.GetAsync("abouts");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
            return values;
        }

        // ID'ye göre kategori getir
        public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("abouts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateAboutDto>();
            return values;
        }

        // GÜNCELLE
        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDto>("abouts", updateAboutDto);
        }
    }
}
