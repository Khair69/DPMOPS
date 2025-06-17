#nullable disable
using DPMOPS.Data;
using DPMOPS.Services.Follow.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.Follow
{
    public class FollowService : IFollowService
    {
        private readonly ApplicationDbContext _context;

        public FollowService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> FollowAsync(FollowDto Fdto)
        {
            var request = await _context.ServiceRequests
                .FindAsync(Fdto.ServiceRequestId);
            if (request == null || !request.IsPublic)
            {
                return false;
            }

            bool alreadyFollowing = await _context.RequestFollowers
                .AnyAsync(f => f.CitizenId == Fdto.CitizenId && f.ServiceRequestId == Fdto.ServiceRequestId);

            if (!alreadyFollowing)
            {
                _context.RequestFollowers.Add(new Models.RequestFollower
                {
                    Id = Guid.NewGuid(),
                    CitizenId = Fdto.CitizenId,
                    ServiceRequestId = Fdto.ServiceRequestId
                });
                var succ = await _context.SaveChangesAsync();

                return succ == 1;
            }
            return false;
        }

        public async Task<IList<FollowingDto>> GetFollowingAsync(string userId)
        {
            return await _context.RequestFollowers
                .Where(f => f.CitizenId == userId)
                .Include(f => f.ServiceRequest)
                    .ThenInclude(sr => sr.Citizen)
                .Select(f => new FollowingDto
                {
                    Id = f.Id,
                    ServiceRequestId = f.ServiceRequestId,
                    FollowedAt = f.FollowedAt,
                    RequestTitle = f.ServiceRequest.Title,
                    RequestOwnerName = f.ServiceRequest.Citizen.FirstName + " " + f.ServiceRequest.Citizen.LastName,
                    StatusId = f.ServiceRequest.StatusId
                })
                .ToListAsync();
        }

        public async Task<IList<string>> GetFollowingIds(Guid id)
        {
            return await _context.RequestFollowers
                .Where(f => f.ServiceRequestId == id)
                .Select(f => f.CitizenId)
                .ToListAsync();
        }

        public async Task<int> GetRequestFollowCountAsync(Guid Id)
        {
            return await _context.RequestFollowers
                .CountAsync(f => f.ServiceRequestId == Id);
        }

        public async Task<bool> UnfollowAsync(FollowDto Fdto)
        {
            var follower = await _context.RequestFollowers
                .FirstOrDefaultAsync(f => f.CitizenId == Fdto.CitizenId && f.ServiceRequestId == Fdto.ServiceRequestId);

            if (follower != null)
            {
                _context.RequestFollowers.Remove(follower);
                var succ = await _context.SaveChangesAsync();
                return succ == 1;
            }

            return false;
        }

        public async Task<bool> UserIsFollowingReqAsync(FollowDto Fdto)
        {
            return await _context.RequestFollowers
                .AnyAsync(f => f.CitizenId == Fdto.CitizenId && f.ServiceRequestId == Fdto.ServiceRequestId);
        }
    }
}
