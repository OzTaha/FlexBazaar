using FlexBazaar.DtoLayer.CommentDtos;

namespace FlexBazaar.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task<List<ResultCommentDto>> CommentListByProductId(string id);
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(string id);
        Task<UpdateCommentDto> GetByIdCommentAsync(string id);
        Task<int> GetTotalCommentCount();
        Task<int> GetActiveCommentCount();
        Task<int> GetPassiveCommentCount();
    }
}