using DPMOPS.Services.ServiceProvider.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Services.ServiceProvider
{
    public interface IServiceProviderService
    {
        Task<IList<ServiceProviderDto>> GetAllProvidersAsync();
        Task<ServiceProviderDto> GetProviderByIdAsync(Guid id);
        Task<bool> MakeServiceProviderAsync(CreateServiceProviderDto SpDto);
        Task<bool> UpdateServiceProviderAsync(UpdateServiceProviderDto SpDto);
        Task<bool> DeleteServiceProviderAsync(Guid id);
        Task<IEnumerable<SelectListItem>> GetServiceProvidersOptionsAsync();
    }
}
