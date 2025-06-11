namespace Insurance.Domain.Strategies;

public class DefaultInsurancePriceCalculator : IInsuranceCalculatorStrategy
{
    public string InsuranceCode => "Default";

    public decimal CalculatePrice(Entities.Insurance insurance)
    {
        // Default implementation for calculating insurance price
        // This could be a simple calculation or a more complex one based on the insurance type
        return insurance.InsuranceProduct.BasePrice;
    }

    public Task<object?> FetchAdditionalInformationAsync(Entities.Insurance insurance)
    {
        // Default implementation for fetching additional information
        // This could be an API call or database query
        return Task.FromResult<object?>(null);
    }
}
