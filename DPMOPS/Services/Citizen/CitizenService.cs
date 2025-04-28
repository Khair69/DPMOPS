using DPMOPS.Data;
using DPMOPS.Services.Citizen.Dtos;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.Citizen
{
    public class CitizenService : ICitizenService
    {
        private readonly ApplicationDbContext _context;

        public CitizenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCitizenAsync(string AccId)
        {
            var citizen = new Models.Citizen();
            citizen.CitizenId = Guid.NewGuid();
            citizen.AccountId = AccId;

            _context.Citizens.Add(citizen);
            var res = await _context.SaveChangesAsync();
            return res == 1;
        }

        public async Task<bool> DeleteCitizenAsync(Guid id)
        {
            var existingCitizen = await _context.Citizens
                .Where(c => c.CitizenId == id)
                .FirstOrDefaultAsync();

            if (existingCitizen == null) return false;

            _context.Citizens.Remove(existingCitizen);

            var saveResault = await _context.SaveChangesAsync();
            return saveResault == 1;
        }

        public async Task<IList<CitizenDto>> GetAllCitizensAsync()
        {
            var citizens = await _context.Citizens
                .Include(c => c.Account)
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
            citizenDto.DateOfBirth = citizen.Account.DateOfBirth;
            citizenDto.NumberOfServiceRequests = citizen.ServiceRequests.Count();
            citizenDto.NumberOfReportRequests = citizen.ReportRequests.Count();

            return citizenDto;
        }
    }
}
