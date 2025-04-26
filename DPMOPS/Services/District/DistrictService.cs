using DPMOPS.Data;
using DPMOPS.Services.District.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.District
{
    public class DistrictService : IDistrictService
    {
        private readonly ApplicationDbContext _context;

        public DistrictService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateDistrictAsync(CreateDistrictDto districtDto)
        {
            if (!await _context.Cities.AnyAsync(c => c.CityId == Guid.Parse(districtDto.CityId)))
                return false;

            var district = new Models.District();
            district.DistrictId = Guid.NewGuid();
            district.Name = districtDto.Name;
            district.CityId = Guid.Parse(districtDto.CityId);

            _context.Districts.Add(district);
            var res = await _context.SaveChangesAsync();
            return res == 1;
        }

        public async Task<IList<DistrictDto>> GetDistrictByCityAsync(Guid cityId)
        {
            var districts = await _context.Districts
                .Where(d => d.CityId == cityId)
                .OrderBy(d => d.Name)
                .Include(d => d.City)
                .AsNoTracking()
                .ToListAsync();

            IList<DistrictDto> DistrictsDto = new List<DistrictDto>();
            foreach(var dis in districts)
            {
                DistrictDto districtDto = new DistrictDto();
                districtDto.DistrictId = dis.DistrictId;
                districtDto.Name = dis.Name;
                districtDto.CityId = dis.CityId;
                districtDto.CityName = dis.City.Name;
                DistrictsDto.Add(districtDto);
            }
            return DistrictsDto;
        }

        public async Task<DistrictDto> GetDistrictByIdAsync(Guid id)
        {
            var district = await _context.Districts
                .Include(d => d.City)
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.DistrictId == id);
            DistrictDto districtDto = new DistrictDto();
            districtDto.DistrictId = district.DistrictId;
            districtDto.Name = district.Name;
            districtDto.CityId = district.CityId;
            districtDto.CityName = district.City.Name;

            return districtDto;
        }

        public async Task<bool> UpdateDistrictAsync(UpdateDistrictDto districtDto)
        {
            var existingDistrict = await _context.Districts
                .Where(d => d.DistrictId == districtDto.DistrictId)
                .Include(d => d.City)
                .FirstOrDefaultAsync();

            existingDistrict.Name = districtDto.Name;
            existingDistrict.CityId = districtDto.CityId;

            var saveResault = await _context.SaveChangesAsync();
            return saveResault == 1;
        }

        public async Task<bool> DeleteDistrictAsync(Guid id)
        {
            var exsistingDistrict = await _context.Districts
                .Where(d => d.DistrictId == id)
                .FirstOrDefaultAsync();

            if (exsistingDistrict == null) return false;

            _context.Districts.Remove(exsistingDistrict);

            var saveResault = await _context.SaveChangesAsync();
            return saveResault == 1;
        }
    }
}
