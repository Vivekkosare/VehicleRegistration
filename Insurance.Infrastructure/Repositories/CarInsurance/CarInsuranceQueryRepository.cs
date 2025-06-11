
using Insurance.Domain.Interfaces;
using Insurance.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Repositories.CarInsurance;

public class CarInsuranceQueryRepository(InsuranceDbContext _dbContext) : IDomainSpecificInsuranceQueryRepository<Domain.Entities.CarInsurance>
{
    public async Task<IEnumerable<Domain.Entities.CarInsurance>> GetAllDomainSpecificInsurancesAsync()
    {
        var carInsurances = await _dbContext.CarInsurances.ToListAsync();
        if (carInsurances == null || !carInsurances.Any())
        {
            throw new KeyNotFoundException("No car insurances found.");
        }
        return carInsurances;
    }

    public async Task<IEnumerable<Domain.Entities.CarInsurance>> GetDomainSpecificInsurancesByPersonalIdentificationNumberAsync(string personalIdentificationNumber)
    {
        var carInsurance = await _dbContext.CarInsurances
            .Where(ci => ci.PersonalIdentificationNumber == personalIdentificationNumber).ToListAsync();
        if (carInsurance == null || !carInsurance.Any())
        {
            throw new KeyNotFoundException($"No car insurances found for personal identification number: {personalIdentificationNumber}");
        }
        return carInsurance;
    }
}