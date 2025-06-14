using DPMOPS.Data;
using DPMOPS.Services.Comment.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCommentAsync(AddCommentDto cDto)
        {
            await _context.Comments
                .AddAsync(new Models.Comment
                {
                    CommentId = Guid.NewGuid(),
                    ServiceRequestId = cDto.ServiceRequestId,
                    AccountId = cDto.AccountId,
                    Content = cDto.Content
                });
            var succ = await _context.SaveChangesAsync();

            return succ == 1;
        }

        public Task<bool> DeleteCommentAsync(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<CommentDto>> GetAllRequestsCommentsAsync(Guid id)
        {
            return await _context.Comments
                .Where(c => c.ServiceRequestId == id)
                .Select(c => new CommentDto
                {
                    CommentId = c.CommentId,
                    ServiceRequestId = c.ServiceRequestId,
                    AccountId = c.AccountId,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<IList<CommentDto>> GetAllUsersComments(string id)
        {
            return await _context.Comments
                .Where(c => c.AccountId == id)
                .Select(c => new CommentDto
                {
                    CommentId = c.CommentId,
                    ServiceRequestId = c.ServiceRequestId,
                    AccountId = c.AccountId,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();
        }
    }
}
