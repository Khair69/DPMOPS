using DPMOPS.Data;
using DPMOPS.Models;
using DPMOPS.Services.Citizen.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace DPMOPS.Services.Citizen
{
    public class CitizenService : ICitizenService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CitizenService(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> CreateCitizenAsync(string AccId)
        {
            var citizen = new Models.Citizen();
            citizen.CitizenId = Guid.NewGuid();
            citizen.AccountId = AccId;

            _context.Citizens.Add(citizen);
            var res = await _context.SaveChangesAsync();

            if (res == 1)
            {
                var selUser = await _userManager.FindByIdAsync(AccId);
                if (selUser == null) return false;
                var claim = new Claim("IsCitizen", "true");
                var resault = await _userManager.AddClaimAsync(selUser, claim);
                if (resault != null) return true;
                return false;
            }

            return res == 1;
        }

        public async Task<bool> DeleteCitizenAsync(Guid id)
        {
            var existingCitizen = await _context.Citizens
                .Where(c => c.CitizenId == id)
                .FirstOrDefaultAsync();

            if (existingCitizen == null) return false;

            string AccId = existingCitizen.AccountId;

            _context.Citizens.Remove(existingCitizen);

            var saveResault = await _context.SaveChangesAsync();

            if (saveResault == 1)
            {
                var selUser = await _userManager.FindByIdAsync(AccId);
                if (selUser == null) return false;
                var citizenClaims = await _userManager.GetClaimsAsync(selUser);
                var isCitizenClaims = citizenClaims.Where(c => c.Type == "IsCitizen" && c.Value == "true").ToList();

                var res = await _userManager.RemoveClaimsAsync(selUser, isCitizenClaims);
                if (res != null) return true;
                return false;
            }

            return saveResault == 1;
        }

        public async Task<IList<CitizenDto>> GetAllCitizensAsync()
        {
            var citizens = await _context.Citizens
                .Include(c => c.Account)
                .ThenInclude(a => a.District)
                .ThenInclude(a => a.City)
                .Include(c => c.ServiceRequests)
                .Include(c => c.ReportRequests)
                .AsNoTracking()
                .ToListAsync();

            IList<CitizenDto> CitizensDto = new List<CitizenDto>();
            foreach(var citizen in citizens)
            {
                CitizenDto citizenDto = new CitizenDto();
                citizenDto.CitizenId = citizen.CitizenId;
                citizenDto.AccountId = citizen.AccountId;
                citizenDto.CitizenName = (citizen.Account.FirstName +" "+ citizen.Account.LastName);
                citizenDto.CitizenEmail = citizen.Account.Email;
                citizenDto.DistrictId = citizen.Account.DistrictId;
                citizenDto.Address = (citizen.Account.District.City.Name + ", " + citizen.Account.District.Name);
                citizenDto.DateOfBirth = citizen.Account.DateOfBirth;
                citizenDto.NumberOfServiceRequests = citizen.ServiceRequests.Count();
                citizenDto.NumberOfReportRequests = citizen.ReportRequests.Count();
                CitizensDto.Add(citizenDto);
            }
            return CitizensDto;
        }

        public async Task<CitizenDto> GetCitizenByIdAsync(Guid id)
        {
            var citizen = await _context.Citizens
                .Include(c => c.Account)
                .ThenInclude(a => a.District)
                .ThenInclude(a => a.City)
                .Include(c => c.ServiceRequests)
                .Include(c => c.ReportRequests)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CitizenId == id);

            CitizenDto citizenDto = new CitizenDto();
            citizenDto.CitizenId = citizen.CitizenId;
            citizenDto.AccountId = citizen.AccountId;
            citizenDto.CitizenName = (citizen.Account.FirstName +" "+ citizen.Account.LastName);
            citizenDto.CitizenEmail = citizen.Account.Email;
            citizenDto.DistrictId = citizen.Account.DistrictId;
            citizenDto.Address = (citizen.Account.District.City.Name + ", " + citizen.Account.District.Name);
            citizenDto.DateOfBirth = citizen.Account.DateOfBirth;
            citizenDto.NumberOfServiceRequests = citizen.ServiceRequests.Count();
            citizenDto.NumberOfReportRequests = citizen.ReportRequests.Count();

            return citizenDto;
        }
    }
}
