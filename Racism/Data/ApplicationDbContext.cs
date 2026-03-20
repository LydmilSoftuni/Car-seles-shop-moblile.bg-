using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Racism.Models;

namespace Racism.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<UserCar> UserCars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Composite primary key for the join table
            builder.Entity<UserCar>()
                .HasKey(uc => new { uc.UserId, uc.CarId });

            builder.Entity<UserCar>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCars)
                .HasForeignKey(uc => uc.UserId);

            builder.Entity<UserCar>()
                .HasOne(uc => uc.Car)
                .WithMany(c => c.UserCars)
                .HasForeignKey(uc => uc.CarId);
        }
    }
}