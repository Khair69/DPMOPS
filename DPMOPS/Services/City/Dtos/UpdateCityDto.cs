using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.City.Dtos
{
    public class UpdateCityDto
    {
        public Guid CityId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }
    }
}
