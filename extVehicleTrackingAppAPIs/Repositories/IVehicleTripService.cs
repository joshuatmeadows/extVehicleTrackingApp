using extVehicleTrackingAppAPIs.Data;

namespace extVehicleTrackingAppAPIs.Repositories
{
    public interface IVehicleTripService
    {
        Task<IEnumerable<ExtVehicleTrip>> VehicleTripGetByVehicle(int vehicleId);
    }
}
