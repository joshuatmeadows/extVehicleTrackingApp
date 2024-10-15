using extVehicleTrackingAppAPIs.Data;

namespace extVehicleTrackingAppAPIs.Repositories
{
    public interface IVehicleService
    {
        Task<int> VehicleAdd(ExtVehicle vehicle);
    }
}
