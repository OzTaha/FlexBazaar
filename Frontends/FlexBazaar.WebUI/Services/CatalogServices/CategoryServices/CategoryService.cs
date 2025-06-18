using FlexBazaar.DtoLayer.CatalogDtos.CategoryDtos;

namespace FlexBazaar.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // EKLE
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
        }

        // SİL
        public async Task DeleteCategoryAsync(string id)
        {         
            await _httpClient.DeleteAsync("categories?id=" + id);
        }

        // Tüm kategorileri getir
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {

            // 1. yöntem
            var responseMessage = await _httpClient.GetAsync("categories");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();

            // 2. yöntem
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        // ID'ye göre kategori getir
        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("categories/" +id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
            return values;
        }

        // GÜNCELLE
        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
        }
    }
}
