
namespace Insurance.Infrastructure.Repositories.Insurance.QueryRepository.cs;

public class InsuranceQueryRepository : IInsuranceQueryRepository
{
    public Task<IEnumerable<Domain.Entities.Insurance>> GetAllInsurancesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entities.Insurance>> GetInsurancesByPersonalIdentificationNumberAsync(string personalIdentificationNumber)
    {
        throw new NotImplementedException();
    }
}
