namespace InsuranceAPI.Features.Insurances.DTOs;

public record Owner(
    string Name,
    string PersonalIdentificationNumber,
    string Email,
    string PhoneNumber
);

