#nullable disable
using DPMOPS.Data;
using DPMOPS.Services.Complaint.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.Complaint
{
    public class ComplaintService : IComplaintService
    {
        private readonly ApplicationDbContext _context;

        public ComplaintService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> MakeComplaintAsync(MakeComplaintDto complaint)
        {
            await _context.Complaints
                .AddAsync(new Models.Complaint
                {
                    ComplaintId = Guid.NewGuid(),
                    Title = complaint.Title,
                    Description = complaint.Description,
                    CitizenId = complaint.CitizenId,
                    OrganizationId = complaint.OrganizationId,
                    ServiceRequestId = complaint.ServiceRequestId
                });
            var succ = await _context.SaveChangesAsync();

            if (succ == 1)
            {
                //send notification to the organization
            }

            return succ == 1;
        }

        public async Task<bool> ChangeComplaintStatus(ChangeComplaintStatusDto complaint)
        {
            var existing = await _context.Complaints.FindAsync(complaint.ComplaintId);
            if (existing == null || existing.Status == 6)
            {
                return false;
            }
            existing.Status = complaint.StatusId;
            var succ = await _context.SaveChangesAsync();

            if (succ == 1)
            {
                //notification to the citizen
            }

            return succ == 1;
        }

        public async Task<IList<ComplaintDto>> GetAllComplaintsAsync()
        {
            return await _context.Complaints
                .Include(c => c.Citizen)
                .Include(c => c.Organization)
                .Include(c => c.ServiceRequest)
                .Select(c => new ComplaintDto
                {
                    ComplaintId = c.ComplaintId,
                    Title = c.Title,
                    Description = c.Description,
                    CreatedAt = c.CreatedAt,
                    CitizenId = c.CitizenId,
                    OrganizationId = c.OrganizationId,
                    ServiceRequestId = c.ServiceRequestId,
                    StatusId = c.Status,
                    CitizenName = c.Citizen.FirstName + " " + c.Citizen.LastName,
                    OrgName = c.Organization.Name,
                    RequestTitle = c.ServiceRequest.Title,
                    Status = (Enums.ComplaintStatus)c.Status
                })
                .ToListAsync();
        }

        public async Task<IList<ComplaintDto>> GetCitizenComplaintsAsync(string citId)
        {
            return await _context.Complaints
                .Where(c => c.CitizenId == citId)
                .Include(c => c.Citizen)
                .Include(c => c.Organization)
                .Include(c => c.ServiceRequest)
                .Select(c => new ComplaintDto
                {
                    ComplaintId = c.ComplaintId,
                    Title = c.Title,
                    Description = c.Description,
                    CreatedAt = c.CreatedAt,
                    CitizenId = c.CitizenId,
                    OrganizationId = c.OrganizationId,
                    ServiceRequestId = c.ServiceRequestId,
                    StatusId = c.Status,
                    CitizenName = c.Citizen.FirstName + " " + c.Citizen.LastName,
                    OrgName = c.Organization.Name,
                    RequestTitle = c.ServiceRequest.Title,
                    Status = (Enums.ComplaintStatus)c.Status
                })
                .ToListAsync();
        }

        public async Task<IList<ComplaintDto>> GetOrgComplaintsAsync(Guid orgId)
        {
            return await _context.Complaints
                .Where(c => c.OrganizationId == orgId)
                .Include(c => c.Citizen)
                .Include(c => c.Organization)
                .Include(c => c.ServiceRequest)
                .Select(c => new ComplaintDto
                {
                    ComplaintId = c.ComplaintId,
                    Title = c.Title,
                    Description = c.Description,
                    CreatedAt = c.CreatedAt,
                    CitizenId = c.CitizenId,
                    OrganizationId = c.OrganizationId,
                    ServiceRequestId = c.ServiceRequestId,
                    StatusId = c.Status,
                    CitizenName = c.Citizen.FirstName + " " + c.Citizen.LastName,
                    OrgName = c.Organization.Name,
                    RequestTitle = c.ServiceRequest.Title,
                    Status = (Enums.ComplaintStatus)c.Status
                })
                .ToListAsync();
        }

        public async Task<ComplaintDto> GetComplaintByIdAsync(Guid id)
        {
            return await _context.Complaints
                .Where(c => c.ComplaintId == id)
                .Include(c => c.Citizen)
                .Include(c => c.Organization)
                .Include(c => c.ServiceRequest)
                .Select(c => new ComplaintDto
                {
                    ComplaintId = c.ComplaintId,
                    Title = c.Title,
                    Description = c.Description,
                    CreatedAt = c.CreatedAt,
                    CitizenId = c.CitizenId,
                    OrganizationId = c.OrganizationId,
                    ServiceRequestId = c.ServiceRequestId,
                    StatusId = c.Status,
                    CitizenName = c.Citizen.FirstName + " " + c.Citizen.LastName,
                    OrgName = c.Organization.Name,
                    RequestTitle = c.ServiceRequest.Title,
                    Status = (Enums.ComplaintStatus)c.Status
                })
                .FirstOrDefaultAsync();
        }
    }
}
