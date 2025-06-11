namespace Insurance.Domain.Interfaces;

public interface IInsuranceProductCommandRepository
{
    Task<Entities.InsuranceProduct> AddInsuranceProductAsync(Entities.InsuranceProduct insuranceProduct);
    Task<Entities.InsuranceProduct?> GetInsuranceProductByCodeAsync(string insuranceCode);
    Task<Entities.InsuranceProduct?> GetInsuranceProductByIdAsync(int id);
}
