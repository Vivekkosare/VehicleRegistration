using Insurance.Domain.Interfaces;
using Insurance.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Repositories.InsuranceProduct;

public class InsuranceProductQueryRepository(InsuranceDbContext _dbContext) : IInsuranceProductQueryRepository
{
    public async Task<Domain.Entities.InsuranceProduct?> GetInsuranceProductByCodeAsync(string insuranceCode)
    {
        var insuranceProduct = await _dbContext.InsuranceProducts
            .FirstOrDefaultAsync(ip => ip.InsuranceCode == insuranceCode);
        if (insuranceProduct == null)
        {
            throw new KeyNotFoundException($"No insurance product found with code: {insuranceCode}");
        }
        return insuranceProduct;
    }

    public async Task<Domain.Entities.InsuranceProduct?> GetInsuranceProductByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("ID cannot be empty", nameof(id));
        }
        var insuranceProduct = await _dbContext.InsuranceProducts
            .FirstOrDefaultAsync(ip => ip.Id == id);



        if (insuranceProduct == null)
        {
            throw new KeyNotFoundException($"No insurance product found with ID: {id}");
        }
        return insuranceProduct;
    }
}
