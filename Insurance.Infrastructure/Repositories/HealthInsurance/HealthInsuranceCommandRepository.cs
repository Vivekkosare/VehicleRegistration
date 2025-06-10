using Insurance.Infrastructure.DbContexts;

namespace Insurance.Infrastructure.Repositories.HealthInsurance.CommandRepository;

public class HealthInsuranceCommandRepository(InsuranceDbContext _dbContext) : IDomainSpecificInsuranceCommandRepository<Domain.Entities.HealthInsurance>
{
    public async Task<Domain.Entities.HealthInsurance> AddDomainSpecificInsuranceAsync(Domain.Entities.HealthInsurance insurance)
    {
        var newHealthInsurance = await _dbContext.HealthInsurances.AddAsync(insurance);
        await _dbContext.SaveChangesAsync();
        return newHealthInsurance.Entity;
    }
}
