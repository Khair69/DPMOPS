﻿#nullable disable

using DPMOPS.Data;
using DPMOPS.Enums;
using DPMOPS.Services.Account;
using DPMOPS.Services.District;
using DPMOPS.Services.Follow;
using DPMOPS.Services.Notification;
using DPMOPS.Services.Notification.Dtos;
using DPMOPS.Services.Photo;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.ServiceRequest
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoUploadService _photoUploadService;
        private readonly INotificationService _notificationService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IAccountService _accountService;
        private readonly IFollowService _followService;
        private readonly IDistrictService _districtService;

        public ServiceRequestService(ApplicationDbContext context,
            IPhotoUploadService photoUploadService,
            INotificationService notificationService,
            LinkGenerator linkGenerator,
            IAccountService accountService,
            IFollowService followService,
            IDistrictService districtService)
        {
            _context = context;
            _photoUploadService = photoUploadService;
            _notificationService = notificationService;
            _linkGenerator = linkGenerator;
            _accountService = accountService;
            _followService = followService;
            _districtService = districtService;
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
                .Include(sr => sr.Appointment)
                .AsNoTracking()
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
                    EmployeeId = sr.EmployeeId,

                    PhotoPath = sr.PhotoPath,

                    Latitude = sr.Latitude,
                    Longitude = sr.Longitude,

                    AppointmentId = sr.Appointment.AppointmentId,
                    AppointmentDate = sr.Appointment.ScheduledAt,

                    IsPublic = sr.IsPublic,

                    DateCompleted = sr.DateCompleted,
                    Review = sr.Review
                })
                .ToListAsync();
        }

        public async Task<ServiceRequestDto> GetServiceRequestByIdAsync(Guid id)
        {
            return await _context.ServiceRequests
                .Where(sr => sr.ServiceRequestId == id)
                .Include(sr => sr.District)
                    .ThenInclude(d => d.City)
                .Include(sr => sr.Citizen)
                .Include(sr => sr.Employee)
                .Include(sr => sr.Organization)
                .Include(sr => sr.Appointment)
                .AsNoTracking()
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
                    EmployeeId = sr.EmployeeId,

                    PhotoPath = sr.PhotoPath,

                    Latitude = sr.Latitude,
                    Longitude = sr.Longitude,

                    AppointmentId = sr.Appointment.AppointmentId,
                    AppointmentDate = sr.Appointment.ScheduledAt,

                    IsPublic = sr.IsPublic,

                    DateCompleted = sr.DateCompleted,
                    Review = sr.Review
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CreateServiceRequestAsync(CreateServiceRequestDto srDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            string photoPath = null;

            int res = 0;
            try
            {
                if (srDto.PhotoFile != null)
                {
                    photoPath = await _photoUploadService.UploadAsync(srDto.PhotoFile);
                }

                var Sr = new Models.ServiceRequest
                {
                    ServiceRequestId = Guid.NewGuid(),
                    Title = srDto.Title,
                    Description = srDto.Description,
                    LocDescription = srDto.LocDescription,
                    CitizenId = srDto.CitizenId,
                    OrganizationId = srDto.OrganizationId,
                    EmployeeId = srDto.EmployeeId,
                    DistrictId = srDto.DistrictId,
                    PhotoPath = photoPath,
                    Latitude = (double)srDto.Latitude,
                    Longitude = (double)srDto.Longitude,
                    IsPublic = srDto.IsPublic
                };

                _context.ServiceRequests.Add(Sr);
                res = await _context.SaveChangesAsync();

                if (res == 1)
                {
                    var AdminsIds = await _accountService.GetAdminIdsInOrg(srDto.OrganizationId);
                    foreach (var empId in AdminsIds)
                    {
                        CreateNotificationDto notif = new CreateNotificationDto
                        {
                            AccountId = empId,
                            Title = "تم تقديم طلب الى مؤسستك",
                            Body = $"تم تقديم طلب بعنوان {Sr.Title}",
                            Link = _linkGenerator.GetPathByPage(
                                "/ServiceRequest/Info",
                                values: new { id = Sr.ServiceRequestId })
                        };

                        await _notificationService.SaveAsync(notif);
                    }
                }
                await transaction.CommitAsync();
            }
            catch
            {
                if (!string.IsNullOrEmpty(photoPath))
                    _photoUploadService.DeletePhoto(photoPath);

                await transaction.RollbackAsync();
                throw;
            }

            return res == 1;
        }

        public async Task<bool> ChangeRequestStatusAsync(ChangeRequestStatusDto srDto)
        {
            var existingRequest = await _context.ServiceRequests
                .Where(sr => sr.ServiceRequestId == srDto.ServiceRequestId)
                .FirstOrDefaultAsync();

            if (existingRequest != null && existingRequest.StatusId != 6)
            {
                if (srDto.StatusId == 6)
                {
                    //send to citizen
                    CreateNotificationDto finNotif = new CreateNotificationDto
                    {
                        AccountId = existingRequest.CitizenId,
                        Title = "تم انهاء العمل على طلبك",
                        Body = $"الرجاء قم بتقييم العمل على \"{existingRequest.Title}\"",
                        Link = _linkGenerator.GetPathByPage(
                            "/ServiceRequest/Info",
                            values: new { id = existingRequest.ServiceRequestId })
                    };

                    await _notificationService.SaveAsync(finNotif);

                    existingRequest.StatusId = 6;
                    existingRequest.DateCompleted = DateTime.UtcNow;

                    var saveres = await _context.SaveChangesAsync();
                    return saveres == 1;
                }

                //send to citizen
                CreateNotificationDto notif = new CreateNotificationDto
                {
                    AccountId = existingRequest.CitizenId,
                    Title = "تم تغيير حالة طلبك",
                    Body = $"\"{existingRequest.Title}\" تغيرت حالته الى {(Status)srDto.StatusId}",
                    Link = _linkGenerator.GetPathByPage(
                        "/ServiceRequest/Info",
                        values: new { id = existingRequest.ServiceRequestId })
                };

                await _notificationService.SaveAsync(notif);
                //send to followers
                IList<string> FIds = await _followService.GetFollowingIds(srDto.ServiceRequestId);
                foreach (string fId in FIds)
                {
                    CreateNotificationDto notification = new CreateNotificationDto
                    {
                        AccountId = fId,
                        Title = "تم تغير حالة طلب قمت بمتابعته",
                        Body = $"\"{existingRequest.Title}\" تغيرت حالته الى {(Status)srDto.StatusId}",
                        Link = _linkGenerator.GetPathByPage(
                            "/ServiceRequest/Info",
                            values: new { id = existingRequest.ServiceRequestId })
                    };

                    await _notificationService.SaveAsync(notification);
                }


                existingRequest.StatusId = srDto.StatusId;

                var saveresult = await _context.SaveChangesAsync();
                return saveresult == 1;
            }
            return false;
        }

        public async Task<bool> DeleteServiceRequestAsync(Guid id)
        {
            var existingReq = await _context.ServiceRequests
                .Where(sr => sr.ServiceRequestId == id)
                .FirstOrDefaultAsync();

            if (existingReq == null || existingReq.StatusId != 1) return false;

            _context.ServiceRequests.Remove(existingReq);

            var saveresult = await _context.SaveChangesAsync();

            if (saveresult == 1 && !string.IsNullOrEmpty(existingReq.PhotoPath))
            {
                _photoUploadService.DeletePhoto(existingReq.PhotoPath);
            }
            return saveresult == 1;
        }

        public async Task<IList<ServiceRequestDto>> GetServiceRequestsByCitizenAsync(string id)
        {
            return await _context.ServiceRequests
                .Where(sr => sr.CitizenId == id)
                .OrderByDescending(sr => sr.DateCreated)
                .Include(sr => sr.District)
                    .ThenInclude(d => d.City)
                .Include(sr => sr.Citizen)
                .Include(sr => sr.Employee)
                .Include(sr => sr.Organization)
                .AsNoTracking()
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
                    EmployeeId = sr.EmployeeId,

                    PhotoPath = sr.PhotoPath,

                    Latitude = sr.Latitude,
                    Longitude = sr.Longitude,

                    IsPublic = sr.IsPublic,

                    DateCompleted = sr.DateCompleted,
                    Review = sr.Review
                })
                .ToListAsync();
        }

        public async Task<IList<ServiceRequestDto>> GetServiceRequestsByEmployeeAsync(string id)
        {
            return await _context.ServiceRequests
                .Where(sr => sr.EmployeeId == id)
                .OrderByDescending(sr => sr.DateCreated)
                .Include(sr => sr.District)
                    .ThenInclude(d => d.City)
                .Include(sr => sr.Citizen)
                .Include(sr => sr.Employee)
                .Include(sr => sr.Organization)
                .AsNoTracking()
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
                    EmployeeId = sr.EmployeeId,

                    PhotoPath = sr.PhotoPath,

                    Latitude = sr.Latitude,
                    Longitude = sr.Longitude,

                    IsPublic = sr.IsPublic,

                    DateCompleted = sr.DateCompleted,
                    Review = sr.Review
                })
                .ToListAsync();
        }

        public async Task<IList<ServiceRequestDto>> GetServiceRequestsByOrganizationAsync(Guid id)
        {
            return await _context.ServiceRequests
                .Where(sr => sr.OrganizationId == id)
                .OrderByDescending(sr => sr.DateCreated)
                .Include(sr => sr.District)
                    .ThenInclude(d => d.City)
                .Include(sr => sr.Citizen)
                .Include(sr => sr.Employee)
                .Include(sr => sr.Organization)
                .AsNoTracking()
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
                    EmployeeId = sr.EmployeeId,

                    PhotoPath = sr.PhotoPath,

                    Latitude = sr.Latitude,
                    Longitude = sr.Longitude,

                    IsPublic = sr.IsPublic,

                    DateCompleted = sr.DateCompleted,
                    Review = sr.Review
                })
                .ToListAsync();
        }

        public async Task<bool> AssignEmployeeAsync(AssignEmployeeDto srDto)
        {
            var existingRequest = await _context.ServiceRequests
                .FindAsync(srDto.ServiceRequestId);

            if (existingRequest != null)
            {
                if (existingRequest.EmployeeId != null
                    || await _accountService.UserHasClaimAsync(srDto.EmployeeId, "IsOrgAdmin", "true")
                    || await _accountService.ValueOfUserClaimAsync(srDto.EmployeeId, "OrganizationId") != existingRequest.OrganizationId.ToString())
                {
                    return false;
                }
                existingRequest.EmployeeId = srDto.EmployeeId;
                existingRequest.StatusId = 2;

                var saveresult = await _context.SaveChangesAsync();

                if (saveresult == 1)
                {
                    CreateNotificationDto empNotif = new CreateNotificationDto
                    {
                        AccountId = srDto.EmployeeId,
                        Title = "تم تعيينك على الطلب",
                        Body = $"تم تعيينك على \"{existingRequest.Title}\"",
                        Link = _linkGenerator.GetPathByPage(
                        "/ServiceRequest/Info",
                        values: new { id = existingRequest.ServiceRequestId })
                    };
                    CreateNotificationDto citNotif = new CreateNotificationDto
                    {
                        AccountId = existingRequest.CitizenId,
                        Title = "تم قبول طلبك",
                        Body = $"لقد تم قبول طلبك بعنوان \"{existingRequest.Title}\"",
                        Link = _linkGenerator.GetPathByPage(
                        "/ServiceRequest/Info",
                        values: new { id = existingRequest.ServiceRequestId })
                    };

                    await _notificationService.SaveAsync(empNotif);
                    await _notificationService.SaveAsync(citNotif);

                    //send to followers
                    IList<string> FIds = await _followService.GetFollowingIds(srDto.ServiceRequestId);
                    foreach (string fId in FIds)
                    {
                        CreateNotificationDto notification = new CreateNotificationDto
                        {
                            AccountId = fId,
                            Title = "تم قبول الطلب الذي قمت بمتابعته",
                            Body = $"لقد تم قبول الطلب بعنوان \"{existingRequest.Title}\"",
                            Link = _linkGenerator.GetPathByPage(
                                "/ServiceRequest/Info",
                                values: new { id = existingRequest.ServiceRequestId })
                        };

                        await _notificationService.SaveAsync(notification);
                    }
                }

                return saveresult == 1;
            }

            return false;
        }

        public async Task<bool> ChangeEmployeeAsync(AssignEmployeeDto srDto)
        {
            var existingRequest = await _context.ServiceRequests
                .FindAsync(srDto.ServiceRequestId);

            if (existingRequest != null)
            {
                if (existingRequest.EmployeeId == null
                    || await _accountService.UserHasClaimAsync(srDto.EmployeeId, "IsOrgAdmin", "true")
                    || await _accountService.ValueOfUserClaimAsync(srDto.EmployeeId, "OrganizationId") != existingRequest.OrganizationId.ToString())
                {
                    return false;
                }
                existingRequest.EmployeeId = srDto.EmployeeId;

                var saveresult = await _context.SaveChangesAsync();

                if (saveresult == 1)
                {
                    CreateNotificationDto fromNotif = new CreateNotificationDto
                    {
                        AccountId = existingRequest.EmployeeId,
                        Title = "تم إزالتك من الطلب",
                        Body = $"تم إزالتك من \"{existingRequest.Title}\"",
                        Link = _linkGenerator.GetPathByPage("/Index")
                    };
                    CreateNotificationDto toNotif = new CreateNotificationDto
                    {
                        AccountId = srDto.EmployeeId,
                        Title = "تم تعيينك على الطلب",
                        Body = $"تم تعيينك على \"{existingRequest.Title}\"",
                        Link = _linkGenerator.GetPathByPage(
                            "/ServiceRequest/Info",
                            values: new { id = existingRequest.ServiceRequestId })
                    };
                    CreateNotificationDto citNotif = new CreateNotificationDto
                    {
                        AccountId = existingRequest.CitizenId,
                        Title = "تم تعيين موظف جديد",
                        Body = $"تعيين موظف على \"{existingRequest.Title}\"",
                        Link = _linkGenerator.GetPathByPage(
                            "/ServiceRequest/Info",
                            values: new { id = existingRequest.ServiceRequestId })
                    };

                    await _notificationService.SaveAsync(fromNotif);
                    await _notificationService.SaveAsync(toNotif);
                    await _notificationService.SaveAsync(citNotif);
                }

                return saveresult == 1;
            }

            return false;
        }

        public async Task<IList<ServiceRequestDto>> GetAllPublicServiceRequestsAsync(Guid? cityId = null)
        {
            if(cityId.HasValue)
            {
                IList<Guid> districtsIds = await _districtService.GetDistrictsByCityAsync(cityId.Value);
                return await _context.ServiceRequests
                    .OrderByDescending(sr => sr.DateCreated)
                    .Where(sr => sr.IsPublic == true)
                    .Where(sr => districtsIds.Contains((Guid)sr.DistrictId))
                    .Include(sr => sr.District)
                        .ThenInclude(d => d.City)
                    .Include(sr => sr.Citizen)
                    .Include(sr => sr.Employee)
                    .Include(sr => sr.Organization)
                    .Include(sr => sr.Appointment)
                    .AsNoTracking()
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
                        EmployeeId = sr.EmployeeId,

                        PhotoPath = sr.PhotoPath,

                        Latitude = sr.Latitude,
                        Longitude = sr.Longitude,

                        AppointmentId = sr.Appointment.AppointmentId,
                        AppointmentDate = sr.Appointment.ScheduledAt,

                        DateCompleted = sr.DateCompleted,
                        Review = sr.Review
                    })
                    .ToListAsync();
            }

            return await _context.ServiceRequests
                .OrderBy(sr => sr.DateCreated)
                .Where(sr => sr.IsPublic == true)
                .Include(sr => sr.District)
                    .ThenInclude(d => d.City)
                .Include(sr => sr.Citizen)
                .Include(sr => sr.Employee)
                .Include(sr => sr.Organization)
                .Include(sr => sr.Appointment)
                .AsNoTracking()
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
                    EmployeeId = sr.EmployeeId,

                    PhotoPath = sr.PhotoPath,

                    Latitude = sr.Latitude,
                    Longitude = sr.Longitude,

                    AppointmentId = sr.Appointment.AppointmentId,
                    AppointmentDate = sr.Appointment.ScheduledAt,

                    DateCompleted = sr.DateCompleted,
                    Review = sr.Review
                })
                .ToListAsync();
        }

        public async Task<bool> ReviewServiceRequest(ReviewDto reDto)
        {
            var existingRequest = await _context.ServiceRequests
                .FindAsync(reDto.ServiceRequestId);
            if (existingRequest == null || existingRequest.StatusId != 6 || existingRequest.DateCompleted == null) return false;

            existingRequest.Review = reDto.Review;

            var success = await _context.SaveChangesAsync();
            return success == 1;
        }

        public async Task<IEnumerable<SelectListItem>> GetCitizenRequestsOptions(string citId)
        {
            return await _context.ServiceRequests
                .Where(sr => sr.CitizenId == citId)
                .Select(sr => new SelectListItem
                {
                    Value = sr.ServiceRequestId.ToString(),
                    Text = sr.Title,
                })
                .ToListAsync();
        }
    }
}
