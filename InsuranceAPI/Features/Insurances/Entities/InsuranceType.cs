namespace InsuranceAPI.Features.Insurances.Entities;

public class InsuranceType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string InsuranceCode { get; set; }
    public decimal Price { get; set; }
}
