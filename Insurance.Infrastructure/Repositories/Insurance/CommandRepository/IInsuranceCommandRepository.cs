namespace Insurance.Infrastructure.Repositories.Insurance.CommandRepository;

public interface IInsuranceCommandRepository
{
    Task<Domain.Entities.Insurance> AddInsuranceAsync(Domain.Entities.Insurance insurance);
}
