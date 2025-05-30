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
            return await _context.ServiceRequests
                .OrderBy(sr => sr.DateCreated)
                .Include(sr => sr.District)
                    .ThenInclude(d => d.City)
                .Include(sr => sr.Citizen)
                .Include(sr => sr.Employee)
                .Include(sr => sr.Organization)
                .Select(sr => new ServiceRequestDto
                {
                    ServiceRequestId = sr.ServiceRequestId,
                    Title = sr.Title,
                    Description = sr.Description,
                    LocDescription = sr.LocDescription,
                    DateCreated = sr.DateCreated,

                    DistrictId = sr.DistrictId,
                    Address = sr.District.City.Name + ", " + sr.District.Name,
                    Status = (Status)sr.StatusId,

                    CitizenName = sr.Citizen.FirstName + " " + sr.Citizen.LastName,
                    EmployeeName = sr.Employee.FirstName + " " + sr.Employee.LastName,
                    OrganizationName = sr.Organization.Name,

                    CitizenId = sr.Citizen.Id,
                    OrganizationId = sr.OrganizationId,
                    EmployeeId = sr.EmployeeId
                })
                .ToListAsync();
        }

        public Task<ServiceRequestDto> GetServiceRequestByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateServiceRequestAsync(CreateServiceRequestDto srDto)
        {
            var Sr = new Models.ServiceRequest();
            Sr.ServiceRequestId = Guid.NewGuid();
            Sr.Title = srDto.Title;
            Sr.Description = srDto.Description;
            Sr.LocDescription = srDto.LocDescription;
            Sr.CitizenId = srDto.CitizenId;
            Sr.OrganizationId = srDto.OrganizationId;
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

        public Task<IList<ServiceRequestDto>> GetServiceRequestsByCitizenAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ServiceRequestDto>> GetServiceRequestsByEmployeeAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ServiceRequestDto>> GetServiceRequestsByOrganizationAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
