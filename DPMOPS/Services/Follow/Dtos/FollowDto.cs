using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.Follow.Dtos
{
    public class FollowDto
    {
        public Guid ServiceRequestId { get; set; }

        [Required]
        public string? CitizenId { get; set; }
    }
}
