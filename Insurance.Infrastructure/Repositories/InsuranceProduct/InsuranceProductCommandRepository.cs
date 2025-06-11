using Insurance.Domain.Interfaces;
using Insurance.Infrastructure.DbContexts;

namespace Insurance.Infrastructure.Repositories.InsuranceProduct;

public class InsuranceProductCommandRepository(InsuranceDbContext _dbContext) : IInsuranceProductCommandRepository
{
    public async Task<Domain.Entities.InsuranceProduct> AddInsuranceProductAsync(Domain.Entities.InsuranceProduct insuranceProduct)
    {
        if (insuranceProduct == null)
        {
            throw new ArgumentNullException(nameof(insuranceProduct), "Insurance product cannot be null");
        }
        var newInsuranceProduct = await _dbContext.InsuranceProducts.AddAsync(insuranceProduct);
        await _dbContext.SaveChangesAsync();
        return newInsuranceProduct.Entity;

    }
}
