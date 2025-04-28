namespace DPMOPS.Services.Citizen.Dtos
{
    public class CitizenDto
    {
        public Guid CitizenId { get; set; }

        public string? AccountId { get; set; }

        public string? CitizenName { get; set; }

        public string? CitizenEmail { get; set; }

        public Guid DistrictId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int NumberOfServiceRequests { get; set; }

        public int NumberOfReportRequests { get; set; }
    }
}
