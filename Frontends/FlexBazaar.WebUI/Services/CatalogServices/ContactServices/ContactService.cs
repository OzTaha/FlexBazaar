using FlexBazaar.DtoLayer.CatalogDtos.ContactDtos;

namespace FlexBazaar.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // EKLE
        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts", createContactDto);
        }

        // SİL
        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("contacts?id=" + id);
        }

        // Tüm kategorileri getir
        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {

            // 1. yöntem
            var responseMessage = await _httpClient.GetAsync("contacts");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultContactDto>>();

            // 2. yöntem
            //var responseMessage = await _httpClient.GetAsync("contacts");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultContactDto>>();
            return values;
        }

        // ID'ye göre kategori getir
        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("contacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
            return values;
        }

        // GÜNCELLE
        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("contacts", updateContactDto);
        }
    }
}
