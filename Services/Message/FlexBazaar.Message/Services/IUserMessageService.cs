using FlexBazaar.Message.Dtos;

namespace FlexBazaar.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAysnc();
        // ReceiverId'ye mesajları getirir
        Task<List<ResultInboxMessageDto>> GetInboxMessageAysnc(string id);
        // SenderId'ye mesajları getirir
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAysnc(string id);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        // id'ye göre mesajı getirir
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        // toplam mesaj sayısını getirir
        Task<int> GetTotalMessageCount();
        // ReceiverId'ye göre mesaj sayısını getirir
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
