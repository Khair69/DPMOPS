using DPMOPS.Data;
using DPMOPS.Services.Follow.Dtos;
using DPMOPS.Services.ServiceRequest;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.Follow
{
    public class FollowService : IFollowService
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceRequestService _serviceRequestService;

        public FollowService(ApplicationDbContext context,
            IServiceRequestService serviceRequestService)
        {
            _context = context;
            _serviceRequestService = serviceRequestService;
        }

        public async Task<bool> FollowAsync(FollowDto Fdto)
        {
            var request = await _serviceRequestService.GetServiceRequestByIdAsync(Fdto.ServiceRequestId);
            if (request == null || !request.IsPublic)
            {
                return false;
            }

            bool alreadyFollowing = await _context.RequestFollowers
                .AnyAsync(f => f.CitizrnId == Fdto.CitizenId && f.ServiceRequestId == Fdto.ServiceRequestId);

            if (!alreadyFollowing)
            {
                _context.RequestFollowers.Add(new Models.RequestFollower
                {
                    Id = Guid.NewGuid(),
                    CitizrnId = Fdto.CitizenId,
                    ServiceRequestId = Fdto.ServiceRequestId
                });
                var succ = await _context.SaveChangesAsync();

                return succ == 1;
            }
            return false;
        }

        public async Task<int> GetRequestFollowCountAsync(Guid Id)
        {
            return await _context.RequestFollowers
                .CountAsync(f => f.ServiceRequestId == Id);
        }

        public async Task<bool> UnfollowAsync(FollowDto Fdto)
        {
            var follower = await _context.RequestFollowers
                .FirstOrDefaultAsync(f => f.CitizrnId == Fdto.CitizenId && f.ServiceRequestId == Fdto.ServiceRequestId);

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
                .AnyAsync(f => f.CitizrnId == Fdto.CitizenId && f.ServiceRequestId == Fdto.ServiceRequestId);
        }
    }
}
