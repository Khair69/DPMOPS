using System.Security.Claims;

namespace DPMOPS.Services.UserClaim
{
    public interface IUserClaimService
    {
        bool IsAdmin(ClaimsPrincipal user);
        bool IsProvider(ClaimsPrincipal user);
        bool IsCitizen(ClaimsPrincipal user);
    }
}
