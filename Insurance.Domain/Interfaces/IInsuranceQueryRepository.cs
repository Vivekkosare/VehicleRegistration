namespace Insurance.Domain.Interfaces;

public interface IInsuranceQueryRepository
{
    public Task<IEnumerable<Entities.Insurance>> GetAllInsurancesAsync();
    public Task<IEnumerable<Entities.Insurance>> GetInsurancesByPersonalIdentificationNumberAsync(string personalIdentificationNumber);
    public Task<Entities.Insurance?> GetInsuranceByIdAsync(string insuranceId);
}
