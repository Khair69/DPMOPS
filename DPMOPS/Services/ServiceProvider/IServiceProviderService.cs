using DPMOPS.Services.ServiceProvider.Dtos;

namespace DPMOPS.Services.ServiceProvider
{
    public interface IServiceProviderService
    {
        Task<IList<ServiceProviderDto>> GetAllProvidersAsync();
        Task<ServiceProviderDto> GetProviderByIdAsync(Guid id);
        Task<bool> MakeServiceProvider(CreateServiceProviderDto SpDto);
        Task<bool> UpdateServiceProvider(UpdateServiceProviderDto SpDto);
        Task<bool> DeleteServiceProviderAsync(Guid id);
    }
}
