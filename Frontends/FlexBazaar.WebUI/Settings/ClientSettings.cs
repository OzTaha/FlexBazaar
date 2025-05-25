namespace FlexBazaar.WebUI.Settings
{
    public class ClientSettings
    {
        public Client FlexBazaarVisitorClient { get; set; }
        public Client FlexBazaarManagerClient { get; set; }
        public Client FlexBazaarAdminClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
