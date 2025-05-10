using DPMOPS.Data;
using DPMOPS.Services.ServiceType.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace DPMOPS.Services.ServiceType
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly ApplicationDbContext _context;

        public ServiceTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ServiceTypeDto>> GetAllServiceTypesAsync()
        {
            var serviceTypes = await _context.ServiceTypes
                .OrderBy(st => st.Name)
                .Include(st => st.ServiceProviders)
                .AsNoTracking()
                .ToListAsync();

            IList<ServiceTypeDto> StDto = new List<ServiceTypeDto>();
            foreach (var serviceType in serviceTypes) 
            {
                ServiceTypeDto stDto = new ServiceTypeDto();
                stDto.ServiceTypeId = serviceType.ServiceTypeId;
                stDto.Name = serviceType.Name;
                stDto.NumberOfProviders = serviceType.ServiceProviders.Count();
                StDto.Add(stDto);
            }
            return StDto;
        }

        public async Task<ServiceTypeDto> GetServiceTypeByIdAsync(Guid id)
        {
            var serviceType = await _context.ServiceTypes
                .Include(st => st.ServiceProviders)
                .AsNoTracking()
                .FirstOrDefaultAsync(st => st.ServiceTypeId == id);

            ServiceTypeDto StDto = new ServiceTypeDto();
            StDto.ServiceTypeId = serviceType.ServiceTypeId;
            StDto.Name = serviceType.Name;
            StDto.NumberOfProviders = serviceType.ServiceProviders.Count();

            return StDto;
        }

        public async Task<bool> CreateServiceTypeAsync(CreateServiceTypeDto stDto)
        {
            var ServiceType = new Models.ServiceType();
            ServiceType.ServiceTypeId = Guid.NewGuid();
            ServiceType.Name = stDto.Name;

            _context.ServiceTypes.Add(ServiceType);
            var res = await _context.SaveChangesAsync();
            return res == 1;
        }

        public async Task<bool> UpdateServiceTypeAsync(UpdateServiceTypeDto stDto)
        {
            var existingSt = await _context.ServiceTypes
                .Where(st => st.ServiceTypeId == stDto.ServiceTypeId)
                .FirstOrDefaultAsync();

            existingSt.Name = stDto.Name;

            var saveresult = await _context.SaveChangesAsync();
            return saveresult == 1;
        }

        public async Task<bool> DeleteServiceTypeAsync(Guid id)
        {
            var existingSt = await _context.ServiceTypes
                .Where(st => st.ServiceTypeId == id)
                .FirstOrDefaultAsync();

            if (existingSt == null) return false;

            _context.ServiceTypes.Remove(existingSt);

            var saveresult = await _context.SaveChangesAsync();
            return saveresult == 1;
        }

        public async Task<IEnumerable<SelectListItem>> GetServiceTypeOptionsAsync()
        {
            return await _context.ServiceTypes
                .OrderBy(st => st.Name)
                .Select(st => new SelectListItem
                {
                    Value = st.ServiceTypeId.ToString(),
                    Text = st.Name
                })
                .ToListAsync();
        }
    }
}
