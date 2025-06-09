using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.ServiceRequest.Dtos
{
    public class ChangeRequestStatusDto
    {
        public Guid ServiceRequestId { get; set; }

        [Display(Name = "الحالة")]
        [Required(ErrorMessage = "{0} مطلوبة")]
        public int StatusId { get; set; }
    }
}
