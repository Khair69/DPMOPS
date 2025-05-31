using DPMOPS.Models;
using System.Security.Claims;

namespace DPMOPS.Services.UserClaim
{
    public class UserClaimService : IUserClaimService
    {
        public bool IsAdmin(ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Type == "IsAdmin" && x.Value == "true");
        }

        public bool IsCitizen(ClaimsPrincipal user)
        {
            return !user.HasClaim(x => x.Type == "OrganizationId");
        }

        public bool IsEmployee(ClaimsPrincipal user)
        {
            return (user.HasClaim(x => x.Type == "OrganizationId") && !user.HasClaim(x => x.Type == "IsOrgAdmin" && x.Value == "true"));
        }

        public bool IsOrganizationAdmin(ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Type == "IsOrgAdmin" && x.Value == "true");
        }
    }
}
