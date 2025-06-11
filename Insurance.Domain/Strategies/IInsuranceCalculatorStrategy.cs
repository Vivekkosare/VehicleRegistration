namespace Insurance.Domain.Strategies;

public interface IInsuranceCalculatorStrategy
{
    decimal CalculatePrice(Entities.Insurance insurance);
    Task<object?> FetchAdditionalInformationAsync(Entities.Insurance insurance);
}
