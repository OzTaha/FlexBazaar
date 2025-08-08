using FlexBazaar.SignalRRealTimeApi.SignalRServices;
using FlexBazaar.SignalRRealTimeApi.SignalRServices.SignalRCommentServices;
using FlexBazaar.SignalRRealTimeApi.SignalRServices.SignalRMessageServices;
using Microsoft.AspNetCore.SignalR;

namespace FlexBazaar.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        private readonly ISignalRMessageService _signalRMessageService;

        public SignalRHub(ISignalRCommentService signalRCommentService, ISignalRMessageService signalRMessageService)
        {
            _signalRCommentService = signalRCommentService;
            _signalRMessageService = signalRMessageService;
        }
        public async Task SendStatisticCount(string id)
        {
            // string userId = Context.UserIdentifier;
            
            var getTotalCommentCount = _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

            var getTotalMessageCount = _signalRMessageService.GetTotalMessageCountByReceiverId(id);
            await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCount);
        }
    }
}
