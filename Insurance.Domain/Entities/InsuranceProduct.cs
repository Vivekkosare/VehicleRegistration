namespace Insurance.Domain.Entities;

public class InsuranceProduct
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string InsuranceCode { get; set; }
    public decimal BasePrice { get; set; }
}
