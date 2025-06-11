using DPMOPS.Enums;
using DPMOPS.Models;
using System.Security.Claims;

namespace DPMOPS.Services.UserClaim
{
    public class UserClaimService : IUserClaimService
    {
        public UserType ResolveUserType(ClaimsPrincipal user)
        {
            if (user == null || !user.Identity.IsAuthenticated)
                return UserType.Unauthenticated;

            if (user.HasClaim("IsAdmin", "true"))
                return UserType.Admin;

            if (user.HasClaim("IsOrgAdmin", "true"))
                return UserType.OrgAdmin;

            if (!string.IsNullOrEmpty(user.FindFirst("OrganizationId")?.Value))
                return UserType.Employee;

            return UserType.Citizen;
        }
    }
}
