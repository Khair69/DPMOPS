using DPMOPS.Services.City.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Services.City
{
    public interface ICityService
    {
        Task<IList<CityDto>> GetAllCitiesAsync();
        Task<CityDto> GetCityByIdAsync(Guid id);
        Task<bool> CreateCityAsync(CreateCityDto cityDto);
        Task<bool> UpdateCityAsync(UpdateCityDto cityDto);
        Task<bool> DeleteCityAsync(Guid id);
        Task<IEnumerable<SelectListItem>> GetCityOptionsAsync();
    }
}
