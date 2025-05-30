namespace DPMOPS.Services.EmployeePicker
{
    public interface IEmployeePicker
    {
        Task<Guid?> PickAsync(Guid organizationId, Guid cityId);
    }
}
