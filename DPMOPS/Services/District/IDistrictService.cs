using DPMOPS.Services.District.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Services.District
{
    public interface IDistrictService
    {
        Task<IList<DistrictDto>> GetDistrictByCityAsync(Guid cityId);
        Task<DistrictDto> GetDistrictByIdAsync(Guid id);
        Task<bool> CreateDistrictAsync(CreateDistrictDto districtDto);
        Task<bool> UpdateDistrictAsync(UpdateDistrictDto districtDto);
        Task<bool> DeleteDistrictAsync(Guid id);
        Task<IEnumerable<SelectListItem>> GetDistrictOptionsByCityAsync(Guid cityId);
        Task<Guid> GetCityIdByDistrictAsync(Guid id);
        Task<IList<Guid>> GetDistrictsByCityAsync(Guid cityId);
    }
}
