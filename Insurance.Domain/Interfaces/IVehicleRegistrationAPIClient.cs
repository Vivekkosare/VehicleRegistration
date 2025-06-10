namespace Insurance.Domain.Interfaces;

public interface IVehicleRegistrationAPIClient
{
    public Task<object?> GetVehicleRegistrationAsync(string personalIdentificationNumber, string vehicleRegistrationNumber);
}
