namespace FlexBazaar.Basket.Dtos
{
    public class BasketItemDto
    {
        // product id int türünde olursa uzun vadede problem yaşanabilir. Çünkü veriler catalog mikroservisten gelecek. Catalogta product id string olarak tutuluyor.
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
