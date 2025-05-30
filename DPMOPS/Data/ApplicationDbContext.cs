using DPMOPS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>(entity =>
                entity.HasMany(c => c.Districts)
                      .WithOne(d => d.City)
                      .HasForeignKey(d => d.CityId)
                      .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasOne(u => u.District)
                      .WithMany(d => d.Users)
                      .HasForeignKey(u => u.DistrictId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Organization)
                    .WithMany(o => o.Employees)
                    .HasForeignKey(u => u.OrganizationId)
                    .IsRequired(false);
            });


            modelBuilder.Entity<ServiceRequest>(entity =>
            {
                entity.Property(e => e.EmployeeId).IsRequired(false);

                entity.HasOne(sr => sr.Citizen)
                .WithMany(c => c.CitizinServiceRequests)
                .HasForeignKey(sr => sr.CitizenId);

                entity.HasOne(sr => sr.Organization)
                .WithMany(o => o.ServiceRequests)
                .HasForeignKey(sr => sr.OrganizationId);

                entity.HasOne(sr => sr.Employee)
                .WithMany(e => e.EmployeeServiceRequests)
                .HasForeignKey(sr => sr.EmployeeId)
                .IsRequired(false);

                entity.HasOne(sr => sr.District)
                .WithMany(d => d.ServiceRequests)
                .HasForeignKey(sr => sr.DistrictId);
            });

            modelBuilder.Entity<Organization>(entity =>
                entity.HasOne(o => o.City)
                .WithMany(c => c.Organizations)
                .HasForeignKey(o => o.CityId)
            );

            modelBuilder.Entity<ServiceRequest>()
                .Property(e => e.StatusId)
                .HasConversion<int>();
        }
    }
}
