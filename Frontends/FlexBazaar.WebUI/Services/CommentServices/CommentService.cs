using FlexBazaar.DtoLayer.CommentDtos;

namespace FlexBazaar.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // EKLE
        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createCommentDto);
        }

        // SİL
        public async Task DeleteCommentAsync(string id)
        {
            await _httpClient.DeleteAsync("comments?id=" + id);
        }

        // ID'ye göre kategori getir
        public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("comments/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
            return values;
        }

        // Tüm kategorileri getir
        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            // 1. yöntem
            var responseMessage = await _httpClient.GetAsync("comments");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();

            // 2. yöntem
            //var responseMessage = await _httpClient.GetAsync("Comments");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return values;
        }

        // GÜNCELLE
        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
        }
        public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
        {
            // 1. yöntem
            var responseMessage = await _httpClient.GetAsync($"comments/CommentListByProductId/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();

            // 2. yöntem
            //var responseMessage = await _httpClient.GetAsync("Comments/CommentListByProductId/" + id);
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return values;
        }
    }
}
