namespace FlexBazaar.Basket.Dtos
{
    public class BasketTotalDto
    {
        // kullanıcı verileri IdentityServer üzerinden gelecek. IdentityServer'da kullanıcı id string olarak tutuluyor.
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
    }
}
