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

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string discountCode)
        {
            var responseMessage = await _httpClient.GetAsync($"discounts/GetCodeDetailByCode{discountCode}");
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
    }
}
