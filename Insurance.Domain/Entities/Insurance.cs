namespace Insurance.Domain.Entities;

public abstract class Insurance
{
    public Guid Id { get; set; }
    public string PersonalIdentificationNumber { get; set; }
    public Guid InsuranceProductId { get; set; }
    public InsuranceProduct InsuranceProduct { get; set; } // Navigation property for the related InsuranceType entity
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
