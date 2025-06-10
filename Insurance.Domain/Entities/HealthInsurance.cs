using Insurance.Domain.Enums;

namespace Insurance.Domain.Entities;

public class HealthInsurance : Insurance
{
    public PlanChoice Plan { get; set; }

}
