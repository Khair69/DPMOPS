using DPMOPS.Models;

namespace DPMOPS.Services.User
{
    public interface IUserService
    {
        Task<bool> MakeAdminAsync(string Id);
        Task<bool> RemoveAdminAsync(string Id);
        Task<IList<ApplicationUser>> GetAllAdminsAsync();
    }
}
