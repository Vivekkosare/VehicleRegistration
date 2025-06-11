
using Insurance.Domain.Interfaces;
using Insurance.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Repositories.Insurance.QueryRepository.cs;

public class InsuranceQueryRepository(InsuranceDbContext _dbContext) : IInsuranceQueryRepository
{
    public async Task<IEnumerable<Domain.Entities.Insurance>> GetAllInsurancesAsync()
    {
        var insurances = await _dbContext.Insurances.ToListAsync();
        if (insurances == null || !insurances.Any())
        {
            throw new KeyNotFoundException("No insurances found.");
        }
        return insurances;
    }

    public async Task<Domain.Entities.Insurance?> GetInsuranceByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("ID cannot be empty", nameof(id));
        }
        var insurance = await _dbContext.Insurances
            .Include(i => i.InsuranceProduct)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (insurance == null)
        {
            throw new KeyNotFoundException($"No insurance found with ID: {id}");
        }
        return insurance;
    }

    public async Task<IEnumerable<Domain.Entities.Insurance>> GetInsurancesByPersonalIdentificationNumberAsync(string personalIdentificationNumber)
    {
        if (string.IsNullOrWhiteSpace(personalIdentificationNumber))
        {
            throw new ArgumentException("Personal identification number cannot be null or empty", nameof(personalIdentificationNumber));
        }

        var insurances = await _dbContext.Insurances
                    .Include(i => i.InsuranceProduct)
                    .Where(i => i.PersonalIdentificationNumber == personalIdentificationNumber)
                    .ToListAsync();

        if (!insurances.Any())
        {
            throw new KeyNotFoundException($"No insurances found for personal identification number: {personalIdentificationNumber}");
        }

        return insurances;
    }
}
