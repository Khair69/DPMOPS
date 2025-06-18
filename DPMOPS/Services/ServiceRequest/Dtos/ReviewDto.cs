using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.ServiceRequest.Dtos
{
    public class ReviewDto
    {
        public Guid ServiceRequestId { get; set; }

        [Range(1, 5)]
        [Required]
        public int Review { get; set; }
    }
}
