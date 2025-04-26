using DPMOPS.Services.District.Dtos;

namespace DPMOPS.Services.District
{
    public interface IDistrictService
    {
        Task<IList<DistrictDto>> GetDistrictByCityAsync(Guid cityId);
        Task<DistrictDto> GetDistrictByIdAsync(Guid id);
        Task<bool> CreateDistrictAsync(CreateDistrictDto districtDto);
        Task<bool> UpdateDistrictAsync(UpdateDistrictDto districtDto);
        Task<bool> DeleteDistrictAsync(Guid id);
    }
}
