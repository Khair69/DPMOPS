using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.ServiceProvider.Dtos
{
    public class UpdateServiceProviderDto
    {
        public Guid ServiceProviderId { get; set; }

        [Required]
        [Display (Name ="Service Type")]
        public Guid ServiceTypeId { get; set; }
    }
}
