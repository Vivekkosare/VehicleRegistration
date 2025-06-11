
using Insurance.Domain.Interfaces;
using Insurance.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Repositories.HealthInsurance.QueryRepository;

public class HealthInsuranceQueryRepository(InsuranceDbContext _dbContext) : IDomainSpecificInsuranceQueryRepository<Domain.Entities.HealthInsurance>
{
    public async Task<IEnumerable<Domain.Entities.HealthInsurance>> GetAllDomainSpecificInsurancesAsync()
    {
        return await _dbContext.HealthInsurances.ToListAsync();
    }

    public async Task<IEnumerable<Domain.Entities.HealthInsurance>> GetDomainSpecificInsurancesByPersonalIdentificationNumberAsync(string personalIdentificationNumber)
    {
        var healthInsurances = await _dbContext.HealthInsurances
            .Where(hi => hi.PersonalIdentificationNumber == personalIdentificationNumber).ToListAsync();
        if (healthInsurances == null || !healthInsurances.Any())
        {
            throw new KeyNotFoundException($"No health insurances found for personal identification number: {personalIdentificationNumber}");
        }
        return healthInsurances;
    }
}
