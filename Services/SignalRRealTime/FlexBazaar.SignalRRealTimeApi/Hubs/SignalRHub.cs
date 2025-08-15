using FlexBazaar.SignalRRealTimeApi.SignalRServices;
using FlexBazaar.SignalRRealTimeApi.SignalRServices.SignalRCommentServices;
using FlexBazaar.SignalRRealTimeApi.SignalRServices.SignalRMessageServices;
using Microsoft.AspNetCore.SignalR;

namespace FlexBazaar.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        //private readonly ISignalRMessageService _signalRMessageService;

        public SignalRHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }
        public async Task SendStatisticCount()
        {
            // string userId = Context.UserIdentifier;
            
            var getTotalCommentCount = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

           
        }
    }
}
