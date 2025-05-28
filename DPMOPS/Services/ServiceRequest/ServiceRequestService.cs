using DPMOPS.Data;
using DPMOPS.Models;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.ServiceRequest
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ServiceRequestDto>> GetAllServiceRequestsAsync()
        {
            var requests = await _context.ServiceRequests
                .Include(r => r.Citizen)
                .ThenInclude(r => r.Account)
                .Include(r => r.Employee)
                    .ThenInclude(sp => sp.Account)
                .Include(r => r.Employee)
                    .ThenInclude(e => e.ServiceProvider)
                        .ThenInclude(sp => sp.Account)
                .Include(r => r.Employee)
                    .ThenInclude(e => e.ServiceProvider)
                        .ThenInclude(sp => sp.ServiceType)
                .Include(r => r.District)
                    .ThenInclude(d => d.City)
                .AsNoTracking()
                .ToListAsync();
            IList<ServiceRequestDto> SrDto = new List<ServiceRequestDto>();
            foreach(var request in requests)
            {
                ServiceRequestDto srdto = new ServiceRequestDto();
                srdto.ServiceRequestId = request.ServiceRequestId;
                srdto.LocDescription = request.LocDescription;
                srdto.DateCreated = request.DateCreated;
                srdto.Description = request.Description;
                srdto.Title = request.Title;
                srdto.DistrictId = request.DistrictId;
                srdto.Address = (request.District.City.Name + ", " + request.District.Name);
                srdto.Status = (Status)request.StatusId;
                srdto.CitizenId = request.CitizenId;
                srdto.CitizenName = (request.Citizen.Account.FirstName + " " + request.Citizen.Account.LastName);
                srdto.EmployeeId = request.EmployeeId;
                srdto.EmployeeName = (request.Employee?.Account?.FirstName + " " + request.Employee?.Account?.LastName);
                srdto.ProviderName = (request.Employee?.ServiceProvider?.Account?.FirstName + " " + request.Employee?.ServiceProvider?.Account?.LastName);
                srdto.ServiceType = request.Employee?.ServiceProvider?.ServiceType?.Name;

                SrDto.Add(srdto);
            }
            return SrDto;
        }

        public Task<ServiceRequestDto> GetServiceRequestByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateServiceRequestAsync(CreateServiceRequestDto srDto)
        {
            var Sr = new Models.ServiceRequest();
            Sr.ServiceRequestId = Guid.NewGuid();
            Sr.LocDescription = srDto.LocDescription;
            Sr.Description = srDto.Description;
            Sr.Title= srDto.Title;
            Sr.CitizenId = srDto.CitizenId;
            Sr.EmployeeId = srDto.EmployeeId;
            Sr.DistrictId = srDto.DistrictId;

            _context.ServiceRequests.Add(Sr);
            var res = await _context.SaveChangesAsync();
            return res == 1;
        }

        public async Task<bool> ChangeRequestStatusAsync(ChangeRequestStatusDto srDto)
        {
            var existingRequest = await _context.ServiceRequests
                .Where(sr => sr.ServiceRequestId == srDto.ServiceRequestId)
                .FirstOrDefaultAsync();

            existingRequest.StatusId = srDto.StatusId;

            var saveresult = await _context.SaveChangesAsync();
            return saveresult == 1;
        }

        public Task<bool> DeleteServiceRequestAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ServiceRequestDto>> GetServiceRequestsByCitizenAsync(Guid id)
        {
            var requests = await _context.ServiceRequests
                .Where(r => r.CitizenId == id)
                .Include(r => r.Citizen)
                    .ThenInclude(r => r.Account)
                .Include(r => r.Employee)
                    .ThenInclude(sp => sp.Account)
                .Include(r => r.Employee)
                    .ThenInclude(e => e.ServiceProvider)
                        .ThenInclude(sp => sp.Account)
                .Include(r => r.Employee)
                    .ThenInclude(e => e.ServiceProvider)
                        .ThenInclude(sp => sp.ServiceType)
                .Include(r => r.District)
                    .ThenInclude(d => d.City)
                .AsNoTracking()
                .ToListAsync();
            IList<ServiceRequestDto> SrDto = new List<ServiceRequestDto>();
            foreach (var request in requests)
            {
                ServiceRequestDto srdto = new ServiceRequestDto();
                srdto.ServiceRequestId = request.ServiceRequestId;
                srdto.LocDescription = request.LocDescription;
                srdto.DateCreated = request.DateCreated;
                srdto.Description = request.Description;
                srdto.Title = request.Title;
                srdto.DistrictId = request.DistrictId;
                srdto.Address = (request.District.City.Name + ", " + request.District.Name);
                srdto.Status = (Status)request.StatusId;
                srdto.CitizenId = request.CitizenId;
                srdto.CitizenName = (request.Citizen.Account.FirstName + " " + request.Citizen.Account.LastName);
                srdto.EmployeeId = request.EmployeeId;
                srdto.EmployeeName = (request.Employee?.Account?.FirstName + " " + request.Employee?.Account?.LastName);
                srdto.ProviderName = (request.Employee?.ServiceProvider?.Account?.FirstName + " " + request.Employee?.ServiceProvider?.Account?.LastName);
                srdto.ServiceType = request.Employee?.ServiceProvider?.ServiceType?.Name;

                SrDto.Add(srdto);
            }
            return SrDto;
        }

        public async Task<IList<ServiceRequestDto>> GetServiceRequestsByEmployeeAsync(Guid id)
        {
            var requests = await _context.ServiceRequests
                .Where(r => r.EmployeeId == id)
                .Include(r => r.Citizen)
                    .ThenInclude(r => r.Account)
                .Include(r => r.Employee)
                    .ThenInclude(sp => sp.Account)
                .Include(r => r.Employee)
                    .ThenInclude(e => e.ServiceProvider)
                        .ThenInclude(sp => sp.Account)
                .Include(r => r.Employee)
                    .ThenInclude(e => e.ServiceProvider)
                        .ThenInclude(sp => sp.ServiceType)
                .Include(r => r.District)
                    .ThenInclude(d => d.City)
                .AsNoTracking()
                .ToListAsync();
            IList<ServiceRequestDto> SrDto = new List<ServiceRequestDto>();
            foreach (var request in requests)
            {
                ServiceRequestDto srdto = new ServiceRequestDto();
                srdto.ServiceRequestId = request.ServiceRequestId;
                srdto.LocDescription = request.LocDescription;
                srdto.DateCreated = request.DateCreated;
                srdto.Description = request.Description;
                srdto.Title = request.Title;
                srdto.DistrictId = request.DistrictId;
                srdto.Address = (request.District.City.Name + ", " + request.District.Name);
                srdto.Status = (Status)request.StatusId;
                srdto.CitizenId = request.CitizenId;
                srdto.CitizenName = (request.Citizen.Account.FirstName + " " + request.Citizen.Account.LastName);
                srdto.EmployeeId = request.EmployeeId;
                srdto.EmployeeName = (request.Employee.Account.FirstName + " " + request.Employee.Account.LastName);
                srdto.ProviderName = (request.Employee.ServiceProvider.Account.FirstName + " " + request.Employee.ServiceProvider.Account.LastName);
                srdto.ServiceType = request.Employee.ServiceProvider.ServiceType.Name;

                SrDto.Add(srdto);
            }
            return SrDto;

        }

        public async Task<IList<ServiceRequestDto>> GetServiceRequestsByProviderAsync(Guid id)
        {
            var requests = await _context.ServiceRequests
                .Include(r => r.Employee)
                .Where(r => r.Employee.ServiceProviderId == id)
                .Include(r => r.Citizen)
                    .ThenInclude(r => r.Account)
                .Include(r => r.Employee)
                    .ThenInclude(sp => sp.Account)
                .Include(r => r.Employee)
                    .ThenInclude(e => e.ServiceProvider)
                        .ThenInclude(sp => sp.Account)
                .Include(r => r.Employee)
                    .ThenInclude(e => e.ServiceProvider)
                        .ThenInclude(sp => sp.ServiceType)
                .Include(r => r.District)
                    .ThenInclude(d => d.City)
                .AsNoTracking()
                .ToListAsync();
            IList<ServiceRequestDto> SrDto = new List<ServiceRequestDto>();
            foreach (var request in requests)
            {
                ServiceRequestDto srdto = new ServiceRequestDto();
                srdto.ServiceRequestId = request.ServiceRequestId;
                srdto.LocDescription = request.LocDescription;
                srdto.DateCreated = request.DateCreated;
                srdto.Description = request.Description;
                srdto.Title = request.Title;
                srdto.DistrictId = request.DistrictId;
                srdto.Address = (request.District.City.Name + ", " + request.District.Name);
                srdto.Status = (Status)request.StatusId;
                srdto.CitizenId = request.CitizenId;
                srdto.CitizenName = (request.Citizen.Account.FirstName + " " + request.Citizen.Account.LastName);
                srdto.EmployeeId = request.EmployeeId;
                srdto.EmployeeName = (request.Employee.Account.FirstName + " " + request.Employee.Account.LastName);
                srdto.ProviderName = (request.Employee.ServiceProvider.Account.FirstName + " " + request.Employee.ServiceProvider.Account.LastName);
                srdto.ServiceType = request.Employee.ServiceProvider.ServiceType.Name;

                SrDto.Add(srdto);
            }
            return SrDto;
        }
    }
}
