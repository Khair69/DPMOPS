namespace DPMOPS.Services.Complaint.Dtos
{
    public class ChangeComplaintStatusDto
    {
        public Guid ComplaintId { get; set; }
        public int StatusId { get; set; }
    }
}
