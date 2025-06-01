using DPMOPS.Authorization.Requirements;
using DPMOPS.Models;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DPMOPS.Authorization.Handlers
{
    public class UnclaimedOrYoursHandler : AuthorizationHandler<UnclaimedOrYoursRequirement, ServiceRequestDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UnclaimedOrYoursHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UnclaimedOrYoursRequirement requirement, ServiceRequestDto resource)
        {
            //if it's yours bypass
            if (resource.EmployeeId == context.User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                context.Succeed(requirement);
                return;
            }

            //if it's unclaimed and in the same organization as you
            if (resource.EmployeeId == null)
            {
                var appUser = await _userManager.GetUserAsync(context.User);

                if (appUser != null && appUser.OrganizationId == resource.OrganizationId)
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}
