using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.ServiceProvider.Dtos
{
    public class CreateServiceProviderDto
    {
        public string? AccountId { get; set; }

        [Required]
        public Guid ServiceTypeId { get; set; }
    }
}
