namespace Insurance.Domain.Strategies;

public interface IInsuranceCalculatorStrategy
{
    string InsuranceCode { get; }
    decimal CalculatePrice(Entities.Insurance insurance);
    Task<object?> FetchAdditionalInformationAsync(Entities.Insurance insurance);
}
