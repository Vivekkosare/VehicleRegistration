

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurance.Infrastructure.Configurations;

public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance.Domain.Entities.Insurance>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Insurance> builder)
    {
        builder.ToTable("Insurances")
        .HasKey(i => i.Id);
        
        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd();

        builder.Property(i => i.PersonalIdentificationNumber)
            .IsRequired()
            .HasMaxLength(12)
            .IsFixedLength();

        builder.Property(i => i.StartDate)
            .IsRequired()
            .HasColumnType("date");

        builder.Property(i => i.EndDate)
            .IsRequired()
            .HasColumnType("date");

        builder.HasOne(i => i.InsuranceProduct)
            .WithMany()
            .HasForeignKey(i => i.InsuranceProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(i => i.PersonalIdentificationNumber)
            .IsUnique()
            .HasDatabaseName("IX_Insurances_PersonalIdentificationNumber");
        
    }
}
