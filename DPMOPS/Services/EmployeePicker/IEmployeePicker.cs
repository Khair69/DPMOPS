namespace DPMOPS.Services.EmployeePicker
{
    public interface IEmployeePicker
    {
        Task<Guid?> PickAsync(Guid type, Guid city);
    }
}
