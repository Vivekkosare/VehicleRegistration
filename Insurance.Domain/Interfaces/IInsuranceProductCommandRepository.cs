namespace Insurance.Domain.Interfaces;

public interface IInsuranceProductCommandRepository
{
    Task<Entities.InsuranceProduct> AddInsuranceProductAsync(Entities.InsuranceProduct insuranceProduct);
}
