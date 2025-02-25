using FlexBazaar.Basket.Dtos;
using FlexBazaar.Basket.Settings;
using System.Text.Json;

namespace FlexBazaar.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
           var status = await _redisService.GetDb().KeyDeleteAsync(userId);

        }
       
        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            //  Redis üzerinde userId key'i ile saklanan sepet bilgisini asenkron olarak alır.
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            // Redis'ten alınan JSON formatındaki sepet bilgisini (existBasket), BasketTotalDto türünde bir nesneye dönüştürür.
            // BasketTotalDto türündeki nesneyi döner. Bu nesne, kullanıcının sepetindeki ürünlerin toplam bilgilerini içerir.
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
           await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
