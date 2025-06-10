
using Insurance.Infrastructure.DbContexts;

namespace Insurance.Infrastructure.Repositories.PetInsurance;

public class PetInsuranceCommandRepository(InsuranceDbContext _dbContext) : IDomainSpecificInsuranceCommandRepository<Domain.Entities.PetInsurance>
{
    public async Task<Domain.Entities.PetInsurance> AddDomainSpecificInsuranceAsync(Domain.Entities.PetInsurance insurance)
    {
        var newPetInsurance = await _dbContext.PetInsurances.AddAsync(insurance);
        await _dbContext.SaveChangesAsync();
        return newPetInsurance.Entity;
    }
}
