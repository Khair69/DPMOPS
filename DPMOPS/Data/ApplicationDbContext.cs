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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasMany(c => c.Districts)
                      .WithOne(d => d.City)
                      .HasForeignKey(d => d.CityId);
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasOne(u => u.District)
                      .WithMany()
                      .HasForeignKey(u => u.DistrictId)
                      .OnDelete(DeleteBehavior.Restrict); // Or SetNull if you want nulls on delete
            });
        }
    }
}
