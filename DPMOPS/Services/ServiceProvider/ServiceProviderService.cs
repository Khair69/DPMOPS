using DPMOPS.Data;
using DPMOPS.Services.ServiceProvider.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.ServiceProvider
{
    public class ServiceProviderService : IServiceProviderService
    {
        private readonly ApplicationDbContext _context;

        public ServiceProviderService(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<IList<ServiceProviderDto>> GetAllProvidersAsync()
        {
            var providers = await _context.ServiceProviders
                .Include(sp => sp.Account)
                .Include(sp => sp.ServiceType)
                .Include(sp => sp.ServiceRequests)
                .Include(sp => sp.ReportRequests)
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
                spDto.DateOfBirth = provider.Account.DateOfBirth;
                spDto.NumberOfServiceRequests = provider.ServiceRequests.Count();
                spDto.NumberOfReportRequests = provider.ReportRequests.Count();
                SpDto.Add(spDto);

            }
            return SpDto;
        }

        public async Task<ServiceProviderDto> GetProviderByIdAsync(Guid id)
        {
            var provider = await _context.ServiceProviders
                .Include(sp => sp.Account)
                .Include(sp => sp.ServiceType)
                .Include(sp => sp.ServiceRequests)
                .Include(sp => sp.ReportRequests)
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
            spDto.DateOfBirth = provider.Account.DateOfBirth;
            spDto.NumberOfServiceRequests = provider.ServiceRequests.Count();
            spDto.NumberOfReportRequests = provider.ReportRequests.Count();

            return spDto;
        }

        public async Task<bool> MakeServiceProviderAsync(CreateServiceProviderDto SpDto)
        {
            var provider = new Models.ServiceProvider();
            provider.ServiceProviderId = Guid.NewGuid();
            provider.AccountId = SpDto.AccountId;
            provider.ServiceTypeId = SpDto.ServiceTypeId;

            _context.ServiceProviders.Add(provider);
            var res = await _context.SaveChangesAsync();
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

            var saveResault = await _context.SaveChangesAsync();
            return saveResault == 1;
        }

        public async Task<bool> DeleteServiceProviderAsync(Guid id)
        {
            var existingProvider = await _context.ServiceProviders
                .Where(sp => sp.ServiceProviderId == id)
                .FirstOrDefaultAsync();

            if (existingProvider == null) return false;

            _context.ServiceProviders.Remove(existingProvider);

            var saveResault = await _context.SaveChangesAsync();
            return saveResault == 1;
        }
    }
}
