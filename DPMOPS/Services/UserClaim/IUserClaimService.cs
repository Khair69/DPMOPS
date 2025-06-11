using DPMOPS.Enums;
using DPMOPS.Models;
using System.Security.Claims;

namespace DPMOPS.Services.UserClaim
{
    public interface IUserClaimService
    {
        UserType ResolveUserType(ClaimsPrincipal user);
    }
}
