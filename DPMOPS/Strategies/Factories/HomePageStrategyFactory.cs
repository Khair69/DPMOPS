using DPMOPS.Services.UserClaim;
using DPMOPS.Strategies.Interfaces;
using System.Security.Claims;

namespace DPMOPS.Strategies.Factories
{
    public class HomePageStrategyFactory : IHomePageStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserClaimService _claimService;

        public HomePageStrategyFactory(
            IServiceProvider serviceProvider,
            IUserClaimService claimService)
        {
            _serviceProvider = serviceProvider;
            _claimService = claimService;
        }

        public async Task<IHomePageStrategy> CreateStrategyAsync(ClaimsPrincipal user)
        {
            if (user?.Identity?.IsAuthenticated != true)
            {
                return new AnonymousHomeStrategy();
            }

            if (_claimService.IsAdmin(user))
            {
                return ActivatorUtilities.CreateInstance<AdminHomeStrategy>(_serviceProvider);
            }

            if (_claimService.IsCitizen(user))
            {
                return ActivatorUtilities.CreateInstance<CitizenHomeStrategy>(_serviceProvider);
            }

            if (_claimService.IsEmployee(user))
            {
                return ActivatorUtilities.CreateInstance<EmployeeHomeStrategy>(_serviceProvider);
            }

            if (_claimService.IsOrganizationAdmin(user))
            {
                return ActivatorUtilities.CreateInstance<OrgAdminHomeStrategy>(_serviceProvider);
            }

            return new AnonymousHomeStrategy();
        }
    }
}
