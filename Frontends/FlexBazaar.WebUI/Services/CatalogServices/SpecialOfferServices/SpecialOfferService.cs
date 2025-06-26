using FlexBazaar.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace FlexBazaar.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;
        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // EKLE
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", createSpecialOfferDto);
        }

        // SİL
        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("specialoffers?id=" + id);
        }

        // Tüm kategorileri getir
        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {

            // 1. yöntem
            var responseMessage = await _httpClient.GetAsync("specialoffers");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();

            // 2. yöntem
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();
            return values;
        }

        // ID'ye göre kategori getir
        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
            return values;
        }

        // GÜNCELLE
        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", updateSpecialOfferDto);
        }       
    }
}
