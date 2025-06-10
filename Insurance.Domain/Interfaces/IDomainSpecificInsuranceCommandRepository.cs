namespace Insurance.Domain.Interfaces;

public interface IDomainSpecificInsuranceCommandRepository<T> where T : class
{
    public Task<T> AddDomainSpecificInsuranceAsync(T insurance);
}
