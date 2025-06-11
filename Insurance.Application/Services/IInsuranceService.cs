namespace Insurance.Application.Services;

public interface IInsuranceService
{
    Task<Domain.Entities.Insurance> AddInsuranceAsync(Domain.Entities.Insurance insurance);
    Task<Domain.Entities.Insurance> GetInsuranceAsync(int id);
}
