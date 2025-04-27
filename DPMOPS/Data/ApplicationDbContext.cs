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
                      .WithMany()
                      .HasForeignKey(u => u.DistrictId)
                      .OnDelete(DeleteBehavior.Restrict)
            );

            modelBuilder.Entity<Citizen>(entity => 
                entity.HasOne(c => c.Account)
                .WithOne()
                .HasForeignKey<Citizen>(c => c.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<Models.ServiceProvider>(entity =>
                entity.HasOne(sp => sp.Account)
                .WithOne()
                .HasForeignKey<Models.ServiceProvider>(sp => sp.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<Models.ServiceProvider>(entity =>
                    entity.HasOne(sp => sp.ServiceType)
                    .WithMany(st => st.ServiceProviders)
                    .HasForeignKey(sp => sp.ServiceTypeId)
            );
        }
    }
}
