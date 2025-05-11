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
            return user.HasClaim(x => x.Type == "IsCitizen" && x.Value == "true");
        }

        public bool IsEmployee(ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Type == "IsEmployee" && x.Value == "true");
        }

        public bool IsProvider(ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Type == "IsProvider" && x.Value == "true");
        }
    }
}
