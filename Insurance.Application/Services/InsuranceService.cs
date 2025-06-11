
using Insurance.Domain.Factories;
using Insurance.Domain.Interfaces;

namespace Insurance.Application.Services;

public class InsuranceService(InsuranceCalculatorFactory _calculatorFactory,
IInsuranceCommandRepository _commandRepository,
IInsuranceProductQueryRepository _insuranceProductRepo,
IInsuranceQueryRepository _insuranceQueryRepo) : IInsuranceService
{
    public async Task<Domain.Entities.Insurance> AddInsuranceAsync(Domain.Entities.Insurance insurance)
    {
        if (insurance == null)
        {
            throw new ArgumentNullException(nameof(insurance), "Insurance cannot be null");
        }

        var insuranceProduct = await _insuranceProductRepo
                    .GetInsuranceProductByIdAsync(insurance.InsuranceProductId);
        if (insuranceProduct == null)
        {
            throw new KeyNotFoundException($"No insurance product found with ID: {insurance.InsuranceProductId}");
        }
        insurance.InsuranceProduct = insuranceProduct;

        var calculator = _calculatorFactory.Resolve(insurance.InsuranceProduct.InsuranceCode);
        if (calculator == null)
        {
            throw new InvalidOperationException("No suitable calculator found for the provided insurance type.");
        }

        insurance.InsuranceProduct.BasePrice = calculator.CalculatePrice(insurance);
        var newInsurance = await _commandRepository.AddInsuranceAsync(insurance);
        return newInsurance;
    }

    public async Task<Domain.Entities.Insurance> GetInsuranceAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("ID cannot be empty", nameof(id));
        }
        var insurance = await _insuranceQueryRepo.GetInsuranceByIdAsync(id);
        if (insurance == null)
        {
            throw new KeyNotFoundException($"No insurance found with ID: {id}");
        }
        return insurance;
    }

    public async Task<IEnumerable<Domain.Entities.Insurance>> GetInsurancesByPersonalIdentificationNumberAsync(string personalIdentificationNumber)
    {
        if (string.IsNullOrWhiteSpace(personalIdentificationNumber))
        {
            throw new ArgumentException("Personal identification number cannot be null or empty", nameof(personalIdentificationNumber));
        }
        var insurances = await _insuranceQueryRepo
                        .GetInsurancesByPersonalIdentificationNumberAsync(personalIdentificationNumber);
        if (insurances == null || !insurances.Any())
        {
            throw new KeyNotFoundException($"No insurances found for personal identification number: {personalIdentificationNumber}");
        }
        if (insurances.Any(i => i.InsuranceProduct.InsuranceCode == "CAR"))
        {

        }

        return insurances;
    }
}
