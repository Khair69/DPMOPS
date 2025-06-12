#nullable disable
using DPMOPS.Data;
using DPMOPS.Services.City.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Services.City
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _context;

        public CityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCityAsync(CreateCityDto cityDto)
        {
            var city = new Models.City();
            city.CityId = Guid.NewGuid();
            city.Name = cityDto.Name;

            _context.Cities.Add(city);
            var res = await _context.SaveChangesAsync();
            return res == 1;
        }

        public async Task<CityDto> GetCityByIdAsync(Guid id)
        {
            var city = await _context.Cities
                .Include(c => c.Districts)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CityId == id);
            CityDto cityDto = new CityDto();
            cityDto.CityId = city.CityId;
            cityDto.Name = city.Name;
            cityDto.DistrictCount = city.Districts.Count();
            return cityDto;
        }

        public async Task<IList<CityDto>> GetAllCitiesAsync()
        {
            var cities = await _context.Cities
                .OrderBy(c => c.Name)
                .Include(c => c.Districts)
                .AsNoTracking().
                ToListAsync();

            IList<CityDto> CitiesDto = new List<CityDto>();
            foreach(var city in cities)
            {
                CityDto cityDto = new CityDto();
                cityDto.CityId = city.CityId;
                cityDto.Name = city.Name;
                cityDto.DistrictCount = city.Districts.Count();
                CitiesDto.Add(cityDto);
            }
            return CitiesDto;
        }

        public async Task<bool> UpdateCityAsync(UpdateCityDto cityDto)
        {
            var existingCity = await _context.Cities
                .Where(c => c.CityId == cityDto.CityId)
                .FirstOrDefaultAsync();

            existingCity.Name = cityDto.Name;

            var saveresult = await _context.SaveChangesAsync();
            return saveresult == 1;
        }

        public async Task<bool> DeleteCityAsync(Guid id)
        {
            var existingCity = await _context.Cities
                .Where(c => c.CityId == id)
                .FirstOrDefaultAsync();

            if (existingCity == null) return false;

            _context.Cities.Remove(existingCity);

            var saveresult = await _context.SaveChangesAsync();
            return saveresult == 1;
        }

        public async Task<IEnumerable<SelectListItem>> GetCityOptionsAsync()
        {
            return await _context.Cities
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Value = c.CityId.ToString(),
                    Text = c.Name
                })
                .ToListAsync();
        }
    }
}
