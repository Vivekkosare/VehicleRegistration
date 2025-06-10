namespace Insurance.Domain.Strategies;

public class DefaultInsurancePriceCalculator : IInsuranceCalculatorStrategy
{
    public decimal CalculatePrice(Insurance insurance)
    {
        // Default implementation for calculating insurance price
        // This could be a simple calculation or a more complex one based on the insurance type
        return insurance.InsuranceProduct.Price;
    }

    public Task<object?> FetchAdditionalInformationAsync(Insurance insurance)
    {
        // Default implementation for fetching additional information
        // This could be an API call or database query
        return Task.FromResult<object?>(null);
    }
}
