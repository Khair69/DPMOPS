#nullable disable
using DPMOPS.Data;
using DPMOPS.Enums;
using DPMOPS.Services.Account;
using DPMOPS.Services.Complaint.Dtos;
using DPMOPS.Services.Notification;
using DPMOPS.Services.Notification.Dtos;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.Complaint
{
    public class ComplaintService : IComplaintService
    {
        private readonly ApplicationDbContext _context;
        private readonly INotificationService _notificationService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IAccountService _accountService;

        public ComplaintService(ApplicationDbContext context,
            INotificationService notificationService,
            LinkGenerator linkGenerator,
            IAccountService accountService)
        {
            _context = context;
            _notificationService = notificationService;
            _linkGenerator = linkGenerator;
            _accountService = accountService;
        }

        public async Task<bool> MakeComplaintAsync(MakeComplaintDto complaint)
        {
            var Complaint = new Models.Complaint
            {
                ComplaintId = Guid.NewGuid(),
                Title = complaint.Title,
                Description = complaint.Description,
                CitizenId = complaint.CitizenId,
                OrganizationId = complaint.OrganizationId,
                ServiceRequestId = complaint.ServiceRequestId
            };
            await _context.Complaints
                .AddAsync(Complaint);
            var succ = await _context.SaveChangesAsync();

            if (succ == 1)
            {
                //send notification to the organization
                var AdminsIds = await _accountService.GetAdminIdsInOrg(complaint.OrganizationId);
                foreach (var empId in AdminsIds)
                {
                    CreateNotificationDto notif = new CreateNotificationDto
                    {
                        AccountId = empId,
                        Title = "تم تقديم شكوى الى مؤسستك",
                        Body = $"تم تقديم شكوى بعنوان {complaint.Title}",
                        Link = _linkGenerator.GetPathByPage(
                            "/Complaints/Info",
                            values: new { id = Complaint.ComplaintId })
                    };

                    await _notificationService.SaveAsync(notif);
                }
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
                CreateNotificationDto notif = new CreateNotificationDto
                {
                    AccountId = existing.CitizenId,
                    Title = "تم تغيير حالة الشكوى",
                    Body = $"\"{existing.Title}\" تغيرت حالتها الى {(ComplaintStatus)existing.Status}",
                    Link = _linkGenerator.GetPathByPage(
                        "/Complaints/Info",
                        values: new { id = existing.ComplaintId })
                };

                await _notificationService.SaveAsync(notif);
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
                .AsNoTracking()
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
                .AsNoTracking()
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
                .AsNoTracking()
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
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
