using FlexBazaar.DtoLayer.BasketDtos;

namespace FlexBazaar.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();
            if (values == null)
            {
                if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    values = new BasketTotalDto();
                    values.BasketItems.Add(basketItemDto);
                }
            }
            await SaveBasket(values);
        }
        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var resposeMessage = await _httpClient.GetAsync("baskets");
            var values = await resposeMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            // var result = values.BasketItems.Remove(deletedItem);
            //await SaveBasket(values);
            //return true;
            if (deletedItem == null)
            {
                // Silinecek ürün yoksa false dönecek
                return false;
            }

            // Öğeyi bir kere sil
            var result = values.BasketItems.Remove(deletedItem);

            if (result)
            {
                // gerçekten bir öğe silindiyse kaydeecek
                await SaveBasket(values);
            }

            return result;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        }
    }
}
