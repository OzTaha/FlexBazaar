using FlexBazaar.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace FlexBazaar.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;
        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // EKLE
        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("offerdiscounts", createOfferDiscountDto);
        }

        // SİL
        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync("offerdiscounts?id=" + id);
        }

        // Tüm offer discount'u getir
        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {

            // 1. yöntem
            var responseMessage = await _httpClient.GetAsync("offerdiscounts");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOfferDiscountDto>>();

            // 2. yöntem
            //var responseMessage = await _httpClient.GetAsync("offerdiscounts");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOfferDiscountDto>>();
            return values;
        }

        // ID'ye göre offer discount'u getir
        public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("offerdiscounts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateOfferDiscountDto>();
            return values;
        }

        // GÜNCELLE
        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("offerdiscounts", updateOfferDiscountDto);
        }
    }
}
