using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.ServiceProvider.Dtos
{
    public class CreateServiceProviderDto
    {
        [Required]
        public string? AccountId { get; set; }

        public Guid ServiceTypeId { get; set; }
    }
}
