using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechnicalService.Core.Entities;
using TechnicalService.Core.Identity;

namespace TechnicalService.Data.Data
{
    public sealed class MyContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.Surname).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.RegisterDate).HasColumnType("datetime");
            });

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.Property(x => x.Description).HasMaxLength(120).IsRequired(false);
            });

            builder.Entity<ServiceDemand>(entity =>
            {
                entity.HasIndex(x => x.Id);
                entity.Property(x => x.TechnicianId).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Address).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.SurName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Phone).HasMaxLength(13).IsRequired(true);
                entity.Property(x => x.Message).HasMaxLength(300).IsRequired(true);
                entity.Property(x => x.FloorNo).HasMaxLength(2).IsRequired(true);
                entity.Property(x => x.BuildingNo).HasMaxLength(4).IsRequired(true);
                entity.Property(x => x.DoorNo).HasMaxLength(5).IsRequired(true);
                entity.Property(x => x.Email).HasMaxLength(50).IsRequired(true);
                entity.HasOne<ApplicationUser>().WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
               
            });

            builder.Entity<Product>(entity =>
            {
                entity.HasIndex(x => x.Id);
                entity.Property(x => x.Name).IsRequired().HasMaxLength(50);
                entity.Property(x => x.UnitPrice).HasPrecision(8, 2);
            });

        }

        public DbSet<ServiceDemand> ServiceDemands { get; set; }
        public DbSet<Product> Products { get; set; }
    }

}
