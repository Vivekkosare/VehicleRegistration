namespace Insurance.Domain.Entities;

public class PetInsurance : Insurance
{
    public string PetName{ get; set; }
    public string PetType { get; set; } // e.g., Dog, Cat, etc.
}
