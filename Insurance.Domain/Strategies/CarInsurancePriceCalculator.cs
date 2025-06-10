namespace Insurance.Domain.Strategies;

public class CarInsurancePriceCalculator : IInsuranceCalculatorStrategy
{
    public decimal CalculatePrice(Insurance insurance)
    {
        if (insurance is not CarInsurance carInsurance)
        {
            throw new ArgumentException("Invalid insurance type for car insurance price calculation.");
        }

        
        //Custom logic for calculating car insurance price
        // For example, you might consider the car's registration number, age, and other factors
        return insurance.InsuranceProduct.Price;
    }

    public Task<object?> FetchAdditionalInformationAsync(Insurance insurance)
    {
        // Implement logic to fetch additional information if needed
        return Task.FromResult<object?>(null);
    }
}
