namespace Insurance.Domain.Strategies;

public interface IInsuranceCalculatorStrategy
{
    decimal CalculatePrice(Insurance insurance);
    Task<object?> FetchAdditionalInformationAsync(Insurance insurance);
}
