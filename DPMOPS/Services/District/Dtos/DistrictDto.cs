namespace DPMOPS.Services.District.Dtos
{
    public class DistrictDto
    {
        public Guid DistrictId { get; set; }

        public string? Name { get; set; }

        public Guid CityId { get; set; }

        public string? CityName { get; set; }
    }
}
