using DPMOPS.Data;
using DPMOPS.Services.District;
using DPMOPS.Services.Map.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DPMOPS.Services.Map
{
    public class MapService : IMapService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDistrictService _districtService;

        public MapService(ApplicationDbContext context, IDistrictService districtService)
        {
            _context = context;
            _districtService = districtService;
        }

        public async Task<IList<MapPointDto>> GetLocationsByOrg(Guid orgId)
        {
            return await _context.ServiceRequests
                .Where(sr => sr.OrganizationId == orgId)
                .Select(sr => new MapPointDto
                {
                    Latitude = sr.Latitude,
                    Longitude = sr.Longitude,
                    StatusId = sr.StatusId,
                    Title = sr.Title,
                    RequestId = sr.ServiceRequestId
                })
                .ToListAsync();
        }

        public async Task<IList<MapPointDto>> GetAllLocations()
        {
            return await _context.ServiceRequests
            .Select(sr => new MapPointDto
            {
                Latitude = sr.Latitude,
                Longitude = sr.Longitude,
                StatusId = sr.StatusId,
                Title = sr.Title,
                RequestId = sr.ServiceRequestId
            })
            .ToListAsync();
        }

        public async Task<IList<MapPointDto>> GetPublicLocationsAsync(Guid? cityId = null)
        {

            if (cityId.HasValue)
            {
                IList<Guid> districtsIds = await _districtService.GetDistrictsByCityAsync(cityId.Value);
                return await _context.ServiceRequests
                    .Where(sr => sr.IsPublic)
                    .Where(sr => districtsIds.Contains((Guid)sr.DistrictId))
                    .Select(sr => new MapPointDto
                    {
                        Latitude = sr.Latitude,
                        Longitude = sr.Longitude,
                        StatusId = sr.StatusId,
                        Title = sr.Title,
                        RequestId = sr.ServiceRequestId
                    })
                    .ToListAsync();
            }

            return await _context.ServiceRequests
                .Where(sr => sr.IsPublic)
                .Select(sr => new MapPointDto
                {
                    Latitude = sr.Latitude,
                    Longitude = sr.Longitude,
                    StatusId = sr.StatusId,
                    Title = sr.Title,
                    RequestId = sr.ServiceRequestId
                })
                .ToListAsync();
        }

        public async Task<IList<MapPointDto>> GetLocationsByEmp(string empId)
        {
            return await _context.ServiceRequests
                .Where(sr => sr.EmployeeId == empId)
                .Select(sr => new MapPointDto
                {
                    Latitude = sr.Latitude,
                    Longitude = sr.Longitude,
                    StatusId = sr.StatusId,
                    Title = sr.Title,
                    RequestId = sr.ServiceRequestId
                })
                .ToListAsync();
        }

        public async Task<IList<MapPointDto>> GetLocationsByCit(string citId)
        {
            return await _context.ServiceRequests
                .Where(sr => sr.CitizenId == citId)
                .Select(sr => new MapPointDto
                {
                    Latitude = sr.Latitude,
                    Longitude = sr.Longitude,
                    StatusId = sr.StatusId,
                    Title = sr.Title,
                    RequestId = sr.ServiceRequestId
                })
                .ToListAsync();
        }
    }
}
