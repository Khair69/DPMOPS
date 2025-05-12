using DPMOPS.Data;
using DPMOPS.Models;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.EmployeePicker
{
    public class LeastBusy : IEmployeePicker
    {
        private readonly ApplicationDbContext _context;

        public LeastBusy(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid?> PickAsync(Guid type, Guid city)
        {
            var employees = await _context.Employees
                .Include(e => e.ServiceProvider)
                .Where(e => e.ServiceProvider.ServiceTypeId == type)
                .Include(e => e.ServiceProvider)
                    .ThenInclude(sp => sp.Account)
                        .ThenInclude(a => a.District)
                        .Where(e => e.ServiceProvider.Account.District.CityId == city)
                .Select(e => new
                {
                    Id = e.EmployeeId
                }).ToListAsync();

            List<LeastBusyDto> empWithInfo = new List<LeastBusyDto>();
            foreach (var employee in employees) 
            {
                var requests = await _context.ServiceRequests
                    .Where(sr => sr.EmployeeId == employee.Id)
                    .Where(sr => sr.StatusId == (int)Status.InProgress)
                    .CountAsync();
                empWithInfo.Add(new LeastBusyDto { EmployeeId = employee.Id, NumofInProgReq = requests});
            }

            var leastBusyEmployee = empWithInfo.MinBy(x => x.NumofInProgReq);

            return leastBusyEmployee?.EmployeeId;
        }

        public class LeastBusyDto
        {
            public Guid EmployeeId { get; set; }

            public int NumofInProgReq { get; set; }
        }
    }
}
