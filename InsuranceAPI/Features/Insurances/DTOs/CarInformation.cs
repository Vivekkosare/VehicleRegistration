namespace InsuranceAPI.Features.Insurances.DTOs;

public record CarInformation(
    string Name,
    string RegistrationNumber,
    string Make,
    string Model,
    int Year,
    string Color,
    DateTime RegistrationDate,
    Guid OwnerId,
    Owner Owner
);
