using FlexBazaar.DtoLayer.MessageDtos;

namespace FlexBazaar.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        // ReceiverId'ye mesajları getirir
        Task<List<ResultInboxMessageDto>> GetInboxMessageAysnc(string id);
        // SenderId'ye mesajları getirir
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAysnc(string id);

        Task<int> GetTotalMessageCountByReceiverId(string id);
        //Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        //Task DeleteMessageAsync(int id);
        //// id'ye göre mesajı getirir
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    }
}
