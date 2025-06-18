using DPMOPS.Services.Complaint.Dtos;

namespace DPMOPS.Services.Complaint
{
    public interface IComplaintService
    {
        Task<bool> MakeComplaintAsync(MakeComplaintDto complaint);
        Task<ComplaintDto> GetComplaintByIdAsync(Guid id);
        Task<IList<ComplaintDto>> GetCitizenComplaintsAsync(string citId);
        Task<IList<ComplaintDto>> GetOrgComplaintsAsync(Guid orgId);
        Task<IList<ComplaintDto>> GetAllComplaintsAsync();
        Task<bool> ChangeComplaintStatus(ChangeComplaintStatusDto complaint);
    }
}
