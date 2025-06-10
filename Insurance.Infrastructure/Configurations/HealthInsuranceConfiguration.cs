using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurance.Infrastructure.Configurations;

public class HealthInsuranceConfiguration : IEntityTypeConfiguration<Insurance.Domain.Entities.HealthInsurance>
{
    public void Configure(EntityTypeBuilder<HealthInsurance> builder)
    {
        builder.ToTable("HealthInsurances")
            .HasKey(i => i.Id);

        builder.Property(i => i.Id)
        .IsRequired();

        builder.Property(i => i.Plan)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (Domain.Enums.PlanChoice)Enum.Parse(typeof(Domain.Enums.PlanChoice), v))
            .HasMaxLength(50);
    }
}
