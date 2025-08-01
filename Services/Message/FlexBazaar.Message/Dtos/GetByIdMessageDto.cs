namespace FlexBazaar.Message.Dtos
{
    public class GetByIdMessageDto
    {
        // mesaj id'si
        public int UserMessageId { get; set; }
        // mesaj gönderen kullanıcı id'si
        public string SenderId { get; set; }
        // mesajı alan kullanıcı id'si
        public string ReceiverId { get; set; }
        // mesajın konusu
        public string Subject { get; set; }
        // mesajın içeriği
        public string MessageDetail { get; set; }
        // mesajın okunma durumu
        public bool IsRead { get; set; }
        // mesajın gönderildiği tarih
        public DateTime MessageDate { get; set; }
    }
}
