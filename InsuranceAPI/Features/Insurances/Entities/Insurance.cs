namespace InsuranceAPI.Features.Insurances.Entities;

public class Insurance
{
    public Guid Id { get; set; }
    public string PersonalIdentificationNumber { get; set; }
    public InsuranceType InsuranceType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
