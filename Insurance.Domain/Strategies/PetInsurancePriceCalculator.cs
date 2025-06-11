
namespace Insurance.Domain.Strategies;

public class PetInsurancePriceCalculator : IInsuranceCalculatorStrategy
{
    public string InsuranceCode => "PET";

    public decimal CalculatePrice(Entities.Insurance insurance)
    {
        return insurance.InsuranceProduct.BasePrice; // Example calculation for pet insurance
    }

    public Task<object?> FetchAdditionalInformationAsync(Entities.Insurance insurance)
    {
        // For pet insurance, we might not need additional information, but if needed, we can implement it here
        // For example, fetching pet medical history or breed information from an external service
        return Task.FromResult<object?>(insurance);
    }
}
