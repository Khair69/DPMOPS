using DPMOPS.Data;
using DPMOPS.Models;
using DPMOPS.Services.Citizen.Dtos;
using DPMOPS.Services.ServiceProvider.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace DPMOPS.Services.ServiceProvider
{
    public class ServiceProviderService : IServiceProviderService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServiceProviderService(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IList<ServiceProviderDto>> GetAllProvidersAsync()
        {
            var providers = await _context.ServiceProviders
                .Include(sp => sp.Account)
                    .ThenInclude(a => a.District)
                        .ThenInclude(d => d.City)
                .Include(sp => sp.ServiceType)
                .Include(sp => sp.Employees)
                .AsNoTracking()
                .ToListAsync();

            IList<ServiceProviderDto> SpDto = new List<ServiceProviderDto>();
            foreach (var provider in providers) 
            {
                ServiceProviderDto spDto = new ServiceProviderDto();
                spDto.ServiceProviderId = provider.ServiceProviderId;
                spDto.AccountId = provider.AccountId;
                spDto.ProviderName = (provider.Account.FirstName +" "+ provider.Account.LastName);
                spDto.ServiceTypeId = provider.ServiceTypeId;
                spDto.ServiceType = provider.ServiceType.Name;
                spDto.ProviderEmail = provider.Account.Email;
                spDto.DistrictId = provider.Account.DistrictId;
                spDto.Address = (provider.Account.District.City.Name + ", " + provider.Account.District.Name);
                spDto.NumberOfEmployees = provider.Employees.Count();
                SpDto.Add(spDto);

            }
            return SpDto;
        }

        public async Task<ServiceProviderDto> GetProviderByIdAsync(Guid id)
        {
            var provider = await _context.ServiceProviders
                .Include(sp => sp.Account)
                .ThenInclude(a => a.District)
                .ThenInclude(a => a.City)
                .Include(sp => sp.ServiceType)
                .Include(sp => sp.Employees)
                .AsNoTracking()
                .FirstOrDefaultAsync(sp => sp.ServiceProviderId == id);

            ServiceProviderDto spDto = new ServiceProviderDto();
            spDto.ServiceProviderId = provider.ServiceProviderId;
            spDto.AccountId = provider.AccountId;
            spDto.ProviderName = (provider.Account.FirstName + " " + provider.Account.LastName);
            spDto.ServiceTypeId = provider.ServiceTypeId;
            spDto.ServiceType = provider.ServiceType.Name;
            spDto.ProviderEmail = provider.Account.Email;
            spDto.DistrictId = provider.Account.DistrictId;
            spDto.Address = (provider.Account.District.City.Name + ", " + provider.Account.District.Name);
            spDto.NumberOfEmployees = provider.Employees.Count();

            return spDto;
        }

        public async Task<bool> AddServiceProviderAsync(CreateServiceProviderDto SpDto)
        {
            var provider = new Models.ServiceProvider();
            provider.ServiceProviderId = Guid.NewGuid();
            provider.AccountId = SpDto.AccountId;
            provider.ServiceTypeId = SpDto.ServiceTypeId;

            _context.ServiceProviders.Add(provider);
            var res = await _context.SaveChangesAsync();

            if (res == 1)
            {
                var selUser = await _userManager.FindByIdAsync(SpDto.AccountId);
                if (selUser == null) return false;
                var claim = new Claim("IsProvider", "true");
                var result = await _userManager.AddClaimAsync(selUser, claim);
                if (result != null) return true;
                return false;
            }

            return res == 1;
        }

        public async Task<bool> UpdateServiceProviderAsync(UpdateServiceProviderDto SpDto)
        {
            var existingProvider = await _context.ServiceProviders
                .Where(sp => sp.ServiceProviderId == SpDto.ServiceProviderId)
                .Include(sp => sp.ServiceType)
                .FirstOrDefaultAsync();

            if (existingProvider == null) return false;

            existingProvider.ServiceTypeId = SpDto.ServiceTypeId;

            var saveresult = await _context.SaveChangesAsync();
            return saveresult == 1;
        }

        public async Task<bool> DeleteServiceProviderAsync(Guid id)
        {
            var existingProvider = await _context.ServiceProviders
                .Where(sp => sp.ServiceProviderId == id)
                .FirstOrDefaultAsync();

            if (existingProvider == null) return false;

            string AccId = existingProvider.AccountId;

            _context.ServiceProviders.Remove(existingProvider);

            var saveresult = await _context.SaveChangesAsync();

            if (saveresult == 1)
            {
                var selUser = await _userManager.FindByIdAsync(AccId);
                if (selUser == null) return false;
                var providerClaims = await _userManager.GetClaimsAsync(selUser);
                var isProviderClaims = providerClaims.Where(c => c.Type == "IsProvider" && c.Value == "true").ToList();

                var res = await _userManager.RemoveClaimsAsync(selUser, isProviderClaims);
                if (res != null) return true;
                return false;
            }

            return saveresult == 1;
        }

        public async Task<IEnumerable<SelectListItem>> GetServiceProvidersOptionsAsync()
        {
            return await _context.ServiceProviders
                .Include(sp => sp.Account)
                .Select(sp => new SelectListItem
                {
                    Value = sp.ServiceProviderId.ToString(),
                    Text = (sp.Account.FirstName +" "+ sp.Account.LastName)
                })
                .ToListAsync();
        }
    }
}
