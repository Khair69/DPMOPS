﻿using DPMOPS.Data;
using DPMOPS.Services.Comment.Dtos;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHtmlSanitizer _htmlSanitizer;

        public CommentService(ApplicationDbContext context,
            IHtmlSanitizer htmlSanitizer)
        {
            _context = context;
            _htmlSanitizer = htmlSanitizer;
        }

        public async Task<bool> AddCommentAsync(AddCommentDto cDto)
        {
            var request = await _context.ServiceRequests
                .FindAsync(cDto.ServiceRequestId);

            if (request == null || request.IsPublic == false)
            {
                return false;
            }

            var sanitizer = new HtmlSanitizer();
            sanitizer.AllowedTags.Clear();
            sanitizer.AllowedAttributes.Clear();

            await _context.Comments
                .AddAsync(new Models.Comment
                {
                    CommentId = Guid.NewGuid(),
                    ServiceRequestId = cDto.ServiceRequestId,
                    AccountId = cDto.AccountId,
                    Content = sanitizer.Sanitize(cDto.Content)
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
                .Include(c => c.Account)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CommentDto
                {
                    CommentId = c.CommentId,
                    ServiceRequestId = c.ServiceRequestId,
                    AccountId = c.AccountId,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    UserName = c.Account.FirstName + " " + c.Account.LastName
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<CommentDto>> GetAllUsersComments(string id)
        {
            return await _context.Comments
                .Where(c => c.AccountId == id)
                .Include(c => c.Account)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CommentDto
                {
                    CommentId = c.CommentId,
                    ServiceRequestId = c.ServiceRequestId,
                    AccountId = c.AccountId,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    UserName = c.Account.FirstName + " " + c.Account.LastName
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
