
using Insurance.Domain.Interfaces;
using Insurance.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Repositories.PetInsurance;

public class PetInsuranceQueryRepository(InsuranceDbContext _dbContext) : IDomainSpecificInsuranceQueryRepository<Domain.Entities.PetInsurance>
{
    public async Task<IEnumerable<Domain.Entities.PetInsurance>> GetAllDomainSpecificInsurancesAsync()
    {
        return await _dbContext.PetInsurances.ToListAsync();
    }

    public async Task<IEnumerable<Domain.Entities.PetInsurance>> GetDomainSpecificInsurancesByPersonalIdentificationNumberAsync(string personalIdentificationNumber)
    {
        var petInsurances = await _dbContext.PetInsurances
            .Where(pi => pi.PersonalIdentificationNumber == personalIdentificationNumber)
            .ToListAsync();

        if (petInsurances == null || !petInsurances.Any())
        {
            throw new KeyNotFoundException($"No pet insurances found for personal identification number: {personalIdentificationNumber}");
        }

        return petInsurances;
    }
}
