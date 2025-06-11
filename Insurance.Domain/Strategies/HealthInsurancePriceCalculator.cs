
namespace Insurance.Domain.Strategies;

public class HealthInsurancePriceCalculator : IInsuranceCalculatorStrategy
{
    public string InsuranceCode => "HEALTH";

    public decimal CalculatePrice(Entities.Insurance insurance)
    {
        return insurance.InsuranceProduct.BasePrice; // Example calculation for health insurance
    }

    public Task<object?> FetchAdditionalInformationAsync(Entities.Insurance insurance)
    {
        return Task.FromResult<object?>(insurance);
    }
}
