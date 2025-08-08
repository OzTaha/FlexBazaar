namespace FlexBazaar.SignalRRealTimeApi.SignalRServices.SignalRCommentServices
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalCommentCount();
    }
}
