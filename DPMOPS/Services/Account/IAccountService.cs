using DPMOPS.Services.Account.Dtos;

namespace DPMOPS.Services.Account
{
    public interface IAccountService
    {
        Task<IList<AccountDto>> GetCitizensAsync();
        Task<IList<AccountDto>> GetEmployeesAsync();
    }
}
