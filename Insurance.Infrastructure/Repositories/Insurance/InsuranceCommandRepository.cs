
using Insurance.Domain.Interfaces;
using Insurance.Infrastructure.DbContexts;
using Insurance.Infrastructure.Repositories.HealthInsurance.CommandRepository;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Repositories.Insurance.CommandRepository;

public class InsuranceCommandRepository(InsuranceDbContext _dbContext) : IInsuranceCommandRepository
{
    private IDomainSpecificInsuranceCommandRepository<dynamic> _domainSpecificInsuranceCommandRepository;
    public async Task<Domain.Entities.Insurance> AddInsuranceAsync(Domain.Entities.Insurance insurance)
    {
        if (insurance == null)
        {
            throw new ArgumentNullException(nameof(insurance), "Insurance cannot be null");
        }
        // if(insurance.InsuranceProduct.InsuranceCode == "CAR")
        var existingInsurance = await _dbContext.Insurances
            .FirstOrDefaultAsync(i => i.PersonalIdentificationNumber == insurance.PersonalIdentificationNumber &&
                                      i.InsuranceProduct.InsuranceCode == insurance.InsuranceProduct.InsuranceCode);
        if (existingInsurance != null)
        {
            throw new InvalidOperationException("Insurance with the same personal identification number and insurance product already exists.");
        }
        switch (insurance.InsuranceProduct.InsuranceCode)
        {
        //     case "CAR":
        //         _domainSpecificInsuranceCommandRepository = new CarInsuranceCommandRepository(dbContext);
        //         break;
            case "HEALTH":
                _domainSpecificInsuranceCommandRepository = (IDomainSpecificInsuranceCommandRepository<dynamic>)new HealthInsuranceCommandRepository(_dbContext);
                await _domainSpecificInsuranceCommandRepository.AddDomainSpecificInsuranceAsync(insurance);
                break;
            // case "TRAVEL":
            //     _domainSpecificInsuranceCommandRepository = new TravelInsuranceCommandRepository(dbContext);
            //     break;
            default:
                throw new NotSupportedException($"Insurance product with code {insurance.InsuranceProduct.InsuranceCode} is not supported.");
        }

        var newInsurance = await _dbContext.Insurances.AddAsync(insurance);
        await _dbContext.SaveChangesAsync();
        return newInsurance.Entity;
    }
}
