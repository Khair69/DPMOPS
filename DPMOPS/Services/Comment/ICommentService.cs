using DPMOPS.Services.Comment.Dtos;

namespace DPMOPS.Services.Comment
{
    public interface ICommentService
    {
        Task<bool> AddCommentAsync(AddCommentDto cDto);
        Task<bool> DeleteCommentAsync(Guid commentId);
        Task<IList<CommentDto>> GetAllRequestsCommentsAsync(Guid id);
        Task<IList<CommentDto>> GetAllUsersComments(string id);
    }
}
