namespace Insurance.Infrastructure.Configurations;

public class CarInsuranceConfiguration : EntityTypeConfiguration<Insurance.Domain.Entities.CarInsurance>
{
    public override void Configure(EntityTypeBuilder<Insurance.Domain.Entities.CarInsurance> builder)
    {
        builder.ToTable("CarInsurances")
            .HasKey(i => i.Id);
        
        builder.Property(c => c.CarRegistrationNumber)
            .IsRequired()
            .HasMaxLength(20);
    }
}
