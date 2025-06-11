using Insurance.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.DbContexts
{
    public class InsuranceDbContext : DbContext
    {
        public DbSet<Insurance.Domain.Entities.Insurance> Insurances { get; set; }
        public DbSet<Insurance.Domain.Entities.InsuranceProduct> InsuranceProducts { get; set; }
        public DbSet<Insurance.Domain.Entities.CarInsurance> CarInsurances { get; set; }
        public DbSet<Insurance.Domain.Entities.HealthInsurance> HealthInsurances { get; set; }
        public DbSet<Insurance.Domain.Entities.PetInsurance> PetInsurances { get; set; }
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Insurance.Domain.Entities.Insurance>(new InsuranceConfiguration());
            modelBuilder.ApplyConfiguration<Insurance.Domain.Entities.InsuranceProduct>(new InsuranceProductConfiguration());
            modelBuilder.ApplyConfiguration<Insurance.Domain.Entities.HealthInsurance>(new HealthInsuranceConfiguration());
            modelBuilder.ApplyConfiguration<Insurance.Domain.Entities.CarInsurance>(new CarInsuranceConfiguration());
            modelBuilder.ApplyConfiguration<Insurance.Domain.Entities.PetInsurance>(new PetInsuranceConfiguration());
            modelBuilder.ApplyConfiguration<Insurance.Domain.Entities.InsuranceProduct>(new InsuranceProductConfiguration());
        }
    }
}
