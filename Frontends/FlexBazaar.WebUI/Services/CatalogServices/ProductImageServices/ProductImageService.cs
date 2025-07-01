using FlexBazaar.DtoLayer.CatalogDtos.ProductImageDtos;

namespace FlexBazaar.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;
        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // EKLE
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimages", createProductImageDto);
        }

        // SİL
        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productimages?id=" + id);
        }

        // ID'ye göre kategori getir
        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return values;
        }

        // Tüm kategorileri getir
        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            // 1. yöntem
            var responseMessage = await _httpClient.GetAsync("productimages");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();

            // 2. yöntem
            //var responseMessage = await _httpClient.GetAsync("productimages");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
            return values;
        }

        // GÜNCELLE
        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productimages", updateProductImageDto);
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/ProductImagesByProductId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return values;
        }      
    }
}
