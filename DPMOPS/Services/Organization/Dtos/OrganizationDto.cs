namespace DPMOPS.Services.Organization.Dtos
{
    public class OrganizationDto
    {
        public Guid OrganizationId { get; set; }

        public string? Name { get; set; }

        public Guid CityId { get; set; }
        public string? CityName { get; set; }

        public int NumberOfEmployees { get; set; }
    }
}
