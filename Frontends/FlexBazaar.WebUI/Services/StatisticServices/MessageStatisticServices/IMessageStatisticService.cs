namespace FlexBazaar.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public interface IMessageStatisticService
    {
        Task<int> GetTotalMessageCount();
    }
}
