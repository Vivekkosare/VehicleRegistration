namespace Insurance.Infrastructure.Repositories;

public interface IDomainSpecificInsuranceCommandRepository<T> where T : class
{
    public Task<T> AddDomainSpecificInsuranceAsync(T insurance);
}
