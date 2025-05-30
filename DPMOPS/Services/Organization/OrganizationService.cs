using DPMOPS.Data;
using DPMOPS.Services.Organization.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.Organization
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ApplicationDbContext _context;

        public OrganizationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateOrganizationAsync(CreateOrganizationDto orgDto)
        {
            var org = new Models.Organization();

            org.OrganizationId = Guid.NewGuid();
            org.Name = orgDto.Name;
            org.CityId = orgDto.CityId;

            _context.Organizations.Add(org);
            var res = await _context.SaveChangesAsync();
            return res == 1;
        }

        public async Task<IList<OrganizationDto>> GetAllOrganizationsAsync()
        {
            return await _context.Organizations
                .OrderBy(o => o.CityId)
                .Include(o => o.City)
                .Include(o => o.Employees)
                .Select(o => new OrganizationDto
                {
                    OrganizationId = o.OrganizationId,
                    Name = o.Name,
                    CityId = o.CityId,
                    CityName = o.City.Name,
                    NumberOfEmployees = o.Employees.Count()
                })
                .ToListAsync();
        }

        public async Task<OrganizationDto> GetOrganizationByIdAsync(Guid id)
        {
            return await _context.Organizations
                .Where(o => o.OrganizationId == id)
                .Include(o => o.City)
                .Include(o => o.Employees)
                .Select(o => new OrganizationDto
                {
                    OrganizationId = o.OrganizationId,
                    Name = o.Name,
                    CityId = o.CityId,
                    CityName = o.City.Name,
                    NumberOfEmployees = o.Employees.Count()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateOrganizationAsync(UpdateOrganizationDto orgDto)
        {
            var existingOrg = await _context.Organizations
                .FirstOrDefaultAsync(o => o.OrganizationId == orgDto.OrganizationId);

            existingOrg.Name = orgDto.Name;

            var saveresult = await _context.SaveChangesAsync();
            return saveresult == 1;
        }
    }
}
