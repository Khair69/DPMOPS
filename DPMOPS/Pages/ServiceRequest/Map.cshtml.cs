using DPMOPS.Enums;
using DPMOPS.Models;
using DPMOPS.Services.City;
using DPMOPS.Services.Map;
using DPMOPS.Services.Map.Dtos;
using DPMOPS.Services.UserClaim;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    public class MapModel : PageModel
    {
        private readonly IMapService _mapService;
        private readonly IUserClaimService _userClaimService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICityService _cityService;

        public MapModel(IMapService mapService,
            IUserClaimService userClaimService,
            UserManager<ApplicationUser> userManager,
            ICityService cityService)
        {
            _mapService = mapService;
            _userClaimService = userClaimService;
            _userManager = userManager;
            _cityService = cityService;
        }

        public IList<MapPointDto> MapPoints { get; set; }
        public IEnumerable<SelectListItem> CityOptions { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid CityId { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IsPublic { get; set; } = false;

        public string Category { get; set; } = "all";

        public async Task OnGetAsync(string? category = "all")
        {
            UserType usertype = _userClaimService.ResolveUserType(User);

            IList<MapPointDto> temp = new List<MapPointDto>();

            if (IsPublic || usertype == UserType.Unauthenticated)
            {
                if (usertype != UserType.Unauthenticated && CityId == Guid.Empty)
                {
                    CityId = _userManager.Users
                        .Where(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier))
                        .Include(u => u.District)
                        .Select(u => u.District.CityId)
                        .FirstOrDefault();
                }
                if (CityId == Guid.Empty)
                {
                    temp = await _mapService.GetPublicLocationsAsync();
                }
                else
                {
                    temp = await _mapService.GetPublicLocationsAsync(CityId);
                }
            }
            else
            {
                switch (usertype)
                {
                    case UserType.Admin:
                        temp = await _mapService.GetAllLocations();
                        break;
                    case UserType.OrgAdmin:
                        temp = await _mapService.GetLocationsByOrg(Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value));
                        break;
                    case UserType.Employee:
                        temp = await _mapService.GetLocationsByEmp(User.FindFirstValue(ClaimTypes.NameIdentifier));
                        break;
                    case UserType.Citizen:
                        temp = await _mapService.GetLocationsByCit(User.FindFirstValue(ClaimTypes.NameIdentifier));
                        break;
                    default:
                        break;
                }
            }

            Category = category ?? "all";

            MapPoints = Category.ToLower() switch
            {
                "all" => temp,
                "pending" => temp.Where(sr => sr.StatusId == 1).ToList(),
                "accepted" => temp.Where(sr => sr.StatusId == 2).ToList(),
                "inprogress" => temp.Where(sr => sr.StatusId == 3).ToList(),
                "suspended" => temp.Where(sr => sr.StatusId == 4).ToList(),
                "denied" => temp.Where(sr => sr.StatusId == 5).ToList(),
                "completed" => temp.Where(sr => sr.StatusId == 6).ToList(),
                _ => temp
            };

            CityOptions = await _cityService.GetCityOptionsAsync();
        }
    }
}
