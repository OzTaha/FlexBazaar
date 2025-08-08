namespace FlexBazaar.SignalRRealTimeApi.SignalRServices.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);        
    }
}
