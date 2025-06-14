using DPMOPS.Services.Follow.Dtos;

namespace DPMOPS.Services.Follow
{
    public interface IFollowService
    {
        Task<bool> FollowAsync(FollowDto Fdto);
        Task<bool> UnfollowAsync(FollowDto Fdto);
        Task<int> GetRequestFollowCountAsync(Guid Id);
        Task<bool> UserIsFollowingReqAsync(FollowDto Fdto);
        Task<IList<string>> GetFollowingIds(Guid id);
    }
}
