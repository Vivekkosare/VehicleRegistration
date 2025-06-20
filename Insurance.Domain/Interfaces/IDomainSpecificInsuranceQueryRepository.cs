namespace Insurance.Domain.Interfaces;

public interface IDomainSpecificInsuranceQueryRepository<T> where T : class
{
    Task<IEnumerable<T>> GetDomainSpecificInsurancesByPersonalIdentificationNumberAsync(string personalIdentificationNumber);
    Task<IEnumerable<T>> GetAllDomainSpecificInsurancesAsync();
}
