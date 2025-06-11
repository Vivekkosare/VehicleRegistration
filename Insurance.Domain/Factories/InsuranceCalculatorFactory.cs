using Insurance.Domain.Strategies;

namespace Insurance.Domain.Factories;

public class InsuranceCalculatorFactory
{
    private readonly Dictionary<string, IInsuranceCalculatorStrategy> _strategies;
    private readonly IInsuranceCalculatorStrategy _defaultStrategy;
    public InsuranceCalculatorFactory(IEnumerable<IInsuranceCalculatorStrategy> strategies,
        IInsuranceCalculatorStrategy defaultStrategy)
    {
        _strategies = strategies.ToDictionary(s => s.InsuranceCode, s => s, StringComparer.OrdinalIgnoreCase);
        _defaultStrategy = defaultStrategy;
    }

    public IInsuranceCalculatorStrategy Resolve(string insuranceCode)
    {
        if (string.IsNullOrWhiteSpace(insuranceCode))
        {
            return _defaultStrategy;
        }

        return _strategies.TryGetValue(insuranceCode, out var strategy)
            ? strategy : _defaultStrategy;
    }
}
