
namespace Insurance.Domain.Strategies;

public class HealthInsurancePriceCalculator : IInsuranceCalculatorStrategy
{
    public decimal CalculatePrice(Entities.Insurance insurance)
    {
        return insurance.InsuranceProduct.Price; // Example calculation for health insurance
    }

    public Task<object?> FetchAdditionalInformationAsync(Entities.Insurance insurance)
    {
        return Task.FromResult<object?>(insurance);
    }
}
