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
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Models.ServiceProvider> ServiceProviders { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<ReportRequest> ReportRequests { get; set; }
        public DbSet<Status> Statuss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>(entity =>
                entity.HasMany(c => c.Districts)
                      .WithOne(d => d.City)
                      .HasForeignKey(d => d.CityId)
            );

            modelBuilder.Entity<ApplicationUser>(entity =>
                entity.HasOne(u => u.District)
                      .WithMany(d => d.Users)
                      .HasForeignKey(u => u.DistrictId)
                      .OnDelete(DeleteBehavior.Restrict)
            );

            modelBuilder.Entity<Citizen>(entity => 
                entity.HasOne(c => c.Account)
                .WithOne(u => u.Citizen)
                .HasForeignKey<Citizen>(c => c.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<Models.ServiceProvider>(entity =>
                entity.HasOne(sp => sp.Account)
                .WithOne(u => u.ServiceProvider)
                .HasForeignKey<Models.ServiceProvider>(sp => sp.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<Models.ServiceProvider>(entity =>
                    entity.HasOne(sp => sp.ServiceType)
                    .WithMany(st => st.ServiceProviders)
                    .HasForeignKey(sp => sp.ServiceTypeId)
            );

            modelBuilder.Entity<ServiceRequest>(entity =>
                   entity.HasOne(sr => sr.Citizen)
                   .WithMany(c => c.ServiceRequests)
                   .HasForeignKey(sr => sr.CitizenId)
            );

            modelBuilder.Entity<ServiceRequest>(entity =>
                   entity.HasOne(sr => sr.ServiceProvider)
                   .WithMany(sp => sp.ServiceRequests)
                   .HasForeignKey(sr => sr.ServiceProviderId)
                   .OnDelete(DeleteBehavior.Restrict)
            );

            modelBuilder.Entity<ServiceRequest>(entity =>
                   entity.HasOne(sr => sr.District)
                   .WithMany(d => d.ServiceRequests)
                   .HasForeignKey(sr => sr.DistrictId)
            );

            modelBuilder.Entity<ReportRequest>(entity =>
                   entity.HasOne(rr => rr.Citizen)
                   .WithMany(c => c.ReportRequests)
                   .HasForeignKey(rr => rr.CitizenId)
            );

            modelBuilder.Entity<ReportRequest>(entity =>
                   entity.HasOne(rr => rr.ServiceProvider)
                   .WithMany(sp => sp.ReportRequests)
                   .HasForeignKey(rr => rr.ServiceProviderId)
                   .OnDelete(DeleteBehavior.Restrict)
            );

            modelBuilder.Entity<ReportRequest>(entity =>
                   entity.HasOne(rr => rr.District)
                   .WithMany(d => d.ReportRequests)
                   .HasForeignKey(rr => rr.ServiceProviderId)
            );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = Guid.Parse("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa"), State = "Pending" },     
                new Status { StatusId = Guid.Parse("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb"), State = "Approved" },     
                new Status { StatusId = Guid.Parse("cccccccc-3333-cccc-3333-cccccccccccc"), State = "InProgress" },       
                new Status { StatusId = Guid.Parse("dddddddd-4444-dddd-4444-dddddddddddd"), State = "Suspended" },     
                new Status { StatusId = Guid.Parse("eeeeeeee-5555-eeee-5555-eeeeeeeeeeee"), State = "Rejected" },     
                new Status { StatusId = Guid.Parse("ffffffff-6666-ffff-6666-ffffffffffff"), State = "Completed" } 
            );
        }
    }
}
