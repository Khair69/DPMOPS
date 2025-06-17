using DPMOPS.Services.Map.Dtos;

namespace DPMOPS.Services.Map
{
    public interface IMapService
    {
        Task<IList<MapPointDto>> GetLocationsByOrg(Guid orgId);
        Task<IList<MapPointDto>> GetAllLocations();
        Task<IList<MapPointDto>> GetPublicLocationsAsync(Guid? cityId = null);
        Task<IList<MapPointDto>> GetLocationsByEmp(string empId);
        Task<IList<MapPointDto>> GetLocationsByCit(string citId);
    }
}
