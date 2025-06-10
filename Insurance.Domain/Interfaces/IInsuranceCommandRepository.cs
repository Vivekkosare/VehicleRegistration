namespace Insurance.Domain.Interfaces;

public interface IInsuranceCommandRepository
{
    Task<Domain.Entities.Insurance> AddInsuranceAsync(Domain.Entities.Insurance insurance);
}
