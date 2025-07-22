using FlexBazaar.DtoLayer.DiscountDtos;

namespace FlexBazaar.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7018/api/Discounts/GetCodeDetailByCodeAsync?Code=BONUS20" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values ?? new GetDiscountCodeDetailByCode
            {
                CouponId = 0,
                Code = string.Empty,
                Rate = 0,
                IsActive = false,
                ValidDate = DateTime.MinValue
            };
        }

        public async Task<int> GetDiscountCouponCountRate(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7018/api/Discounts/GetDiscountCouponCountRate?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values > 0 ? values : 0;
        }
    }
}
