using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces;

namespace Insurance.Domain.Strategies;

public class CarInsurancePriceCalculator(IVehicleRegistrationAPIClient client) : IInsuranceCalculatorStrategy
{
    public decimal CalculatePrice(Entities.Insurance insurance)
    {
        if (insurance is not CarInsurance carInsurance)
        {
            throw new ArgumentException("Invalid insurance type for car insurance price calculation.");
        }

        
        //Custom logic for calculating car insurance price
        // For example, you might consider the car's registration number, age, and other factors
        return insurance.InsuranceProduct.Price;
    }

    public async Task<object?> FetchAdditionalInformationAsync(Entities.Insurance insurance)
    {
        // Implement logic to fetch additional information if needed
        //return Task.FromResult<object?>(null);
        var data = await client.GetVehicleRegistrationAsync(insurance.PersonalIdentificationNumber);
        return data;
    }
}
