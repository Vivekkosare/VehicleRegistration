using Microsoft.EntityFrameworkCore;
using VehicleRegistrationAPI.Entities;

namespace VehicleRegistrationAPI.Data;

public class VehicleRegistrationDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public VehicleRegistrationDbContext(DbContextOptions<VehicleRegistrationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Customer>().HasKey(c => c.Id);
        builder.Entity<Customer>(entity =>
        {
            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);
        });

        builder.Entity<Vehicle>().HasKey(v => v.Id);
        builder.Entity<Vehicle>().HasOne(v => v.Owner)
        .WithMany(v => v.Vehicles)
        .HasForeignKey(v => v.OwnerId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Vehicle>(entity =>
        {
            entity.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(v => v.RegistrationNumber)
                .IsRequired()
                .HasMaxLength(15);
            entity.Property(v => v.Make)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(v => v.Model)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(v => v.Year)
                .IsRequired()
                .HasMaxLength(4);
            entity.Property(v => v.Color)
                .IsRequired()
                .HasMaxLength(30);
            entity.Property(v => v.RegistrationDate)
                .IsRequired()
                .HasColumnType("datetime");
        });

    }
}
