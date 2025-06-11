namespace Insurance.Domain.Interfaces;

public interface IInsuranceProductQueryRepository
{
    Task<Entities.InsuranceProduct?> GetInsuranceProductByCodeAsync(string insuranceCode);
    Task<Entities.InsuranceProduct?> GetInsuranceProductByIdAsync(int id);
}
