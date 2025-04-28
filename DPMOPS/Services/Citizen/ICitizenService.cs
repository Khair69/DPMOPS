using DPMOPS.Services.Citizen.Dtos;

namespace DPMOPS.Services.Citizen
{
    public interface ICitizenService
    {
        Task<IList<CitizenDto>> GetAllCitizensAsync();
        Task<CitizenDto> GetCitizenByIdAsync(Guid id);
        Task<bool> CreateCitizenAsync(string AccId);
        Task<bool> DeleteCitizenAsync(Guid id);
    }
}
