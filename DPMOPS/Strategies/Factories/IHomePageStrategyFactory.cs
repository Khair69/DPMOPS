using DPMOPS.Strategies.Interfaces;
using System.Security.Claims;

namespace DPMOPS.Strategies.Factories
{
    public interface IHomePageStrategyFactory
    {
        Task<IHomePageStrategy> CreateStrategyAsync(ClaimsPrincipal user);
    }
}
