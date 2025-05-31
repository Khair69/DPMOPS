using DPMOPS.Models;
using System.Security.Claims;

namespace DPMOPS.Services.UserClaim
{
    public interface IUserClaimService
    {
        bool IsAdmin(ClaimsPrincipal user);
        bool IsOrganizationAdmin(ClaimsPrincipal user);
        bool IsCitizen(ClaimsPrincipal user);
        bool IsEmployee(ClaimsPrincipal user);
    }
}
