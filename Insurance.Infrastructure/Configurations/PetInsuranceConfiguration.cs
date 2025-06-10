namespace Insurance.Infrastructure.Configurations;

public class PetInsuranceConfiguration : IEntityTypeConfiguration<Insurance.Domain.Entities.PetInsurance>
{
    public void Configure(EntityTypeBuilder<Insurance.Domain.Entities.PetInsurance> builder)
    {
        builder.ToTable("PetInsurances")
            .HasKey(i => i.Id);

        builder.Property(p => p.PetName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.PetType)
            .IsRequired()
            .HasMaxLength(50);
    }
}
