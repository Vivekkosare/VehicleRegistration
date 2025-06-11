using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurance.Infrastructure.Configurations;

public class CarInsuranceConfiguration : IEntityTypeConfiguration<Domain.Entities.CarInsurance>
{
    public void Configure(EntityTypeBuilder<CarInsurance> builder)
    {
        builder.ToTable("CarInsurances")
            .HasKey(i => i.Id);
        
        builder.Property(c => c.CarRegistrationNumber)
            .IsRequired()
            .HasMaxLength(20);
    }
}
