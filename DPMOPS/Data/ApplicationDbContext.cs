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
                    .OnDelete(DeleteBehavior.Restrict)
            );

            modelBuilder.Entity<ServiceRequest>(entity =>
            {
                entity.Property(e => e.CitizenId).IsRequired(false);
                entity.Property(e => e.ServiceProviderId).IsRequired(false);
                //entity.Property(e => e.EmployeeId).IsRequired(false);

                entity.HasOne(sr => sr.Citizen)
                .WithMany(c => c.ServiceRequests)
                .HasForeignKey(sr => sr.CitizenId);

                entity.HasOne(sr => sr.ServiceProvider)
                .WithMany(sp => sp.ServiceRequests)
                .HasForeignKey(sr => sr.ServiceProviderId);

                entity.HasOne(sr => sr.District)
                .WithMany(d => d.ServiceRequests)
                .HasForeignKey(sr => sr.DistrictId);
            });

            modelBuilder.Entity<ServiceRequest>()
                .Property(e => e.StatusId)
                .HasConversion<int>();
        }
    }
}
