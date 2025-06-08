namespace DPMOPS.Services.Account.Dtos
{
    public class AccountDto
    {
        public string? AccountId { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public DateTime DateCreated { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public int NumberOfRequests { get; set; }

        public string? OrganizationName { get; set; }
    }
}
