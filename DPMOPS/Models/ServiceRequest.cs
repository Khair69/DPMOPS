﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DPMOPS.Models
{
    public class ServiceRequest
    {
        public Guid ServiceRequestId { get; set; }

        [Required]
        public string? Title {  get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? LocDescription { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public string? CitizenId { get; set; }
        public Guid? OrganizationId { get; set; }
        [AllowNull]
        public string? EmployeeId { get; set; }
        public Guid? DistrictId { get; set; }
        public int StatusId { get; set; } = 1;

        public ApplicationUser? Citizen { get; set; }
        public ApplicationUser? Employee { get; set; }
        public Organization? Organization { get; set; }
        public District? District { get; set; }

        [AllowNull]
        public string? PhotoPath { get; set; }

        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }

        public Appointment? Appointment { get; set; }
        public bool IsPublic { get; set; } = true;

        [AllowNull]
        public DateTime? DateCompleted { get; set; }
        [AllowNull]
        [Range(1, 5)]
        public int? Review { get; set; }

        // possible add ons:
        // public string ReportType { get; set; } // e.g., "Maintenance", "Complaint"
        // public bool IsUrgent { get; set; }
    }
}
