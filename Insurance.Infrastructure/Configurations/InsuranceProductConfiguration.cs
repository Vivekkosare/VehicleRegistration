using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurance.Infrastructure.Configurations;

public class InsuranceProductConfiguration : IEntityTypeConfiguration<Insurance.Domain.Entities.InsuranceProduct>
{
    public void Configure(EntityTypeBuilder<InsuranceProduct> builder)
    {
        builder.ToTable("InsuranceProducts")
        .HasKey(it => it.Id);

        builder.Property(it => it.Id)
        .ValueGeneratedOnAdd();

        builder.Property(it => it.Name)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(it => it.InsuranceCode)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(it => it.Price)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.HasIndex(it => it.InsuranceCode)
            .IsUnique()
            .HasDatabaseName("IX_InsuranceTypes_InsuranceCode");
            
    }
}
