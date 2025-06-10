namespace Insurance.Domain.Interfaces;

public interface IInsuranceQueryRepository
{
    public Task<IEnumerable<Domain.Entities.Insurance>> GetAllInsurancesAsync();
    public Task<IEnumerable<Domain.Entities.Insurance>> GetInsurancesByPersonalIdentificationNumberAsync(string personalIdentificationNumber);
}
