using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DPMOPS.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 2)]
        [PersonalData]
        public string? FirstName { get; set; }

        [Required]
        [PersonalData]
        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 2)]
        public string? LastName { get; set; }

        [Required]
        [PersonalData]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [Required]
        [PersonalData]
        public Guid DistrictId { get; set; }

        [PersonalData]
        [AllowNull]
        public Guid? OrganizationId { get; set; }

        public District? District { get; set; }
        public Organization? Organization { get; set; }
        public ICollection<ServiceRequest>? CitizinServiceRequests { get; set; }
        public ICollection<ServiceRequest>? EmployeeServiceRequests { get; set; }
    }
}
