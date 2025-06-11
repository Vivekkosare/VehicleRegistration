using Insurance.Domain.Interfaces;
using Insurance.Infrastructure.DbContexts;

namespace Insurance.Infrastructure.Repositories.CarInsurance;

public class CarInsuranceCommandRepository(InsuranceDbContext _dbContext) : IDomainSpecificInsuranceCommandRepository<Domain.Entities.CarInsurance>
{
    public async Task<Domain.Entities.CarInsurance> AddDomainSpecificInsuranceAsync(Domain.Entities.CarInsurance insurance)
    {
        var newCarInsurance = await _dbContext.CarInsurances.AddAsync(insurance);
        await _dbContext.SaveChangesAsync();
        return newCarInsurance.Entity;
    }

}
