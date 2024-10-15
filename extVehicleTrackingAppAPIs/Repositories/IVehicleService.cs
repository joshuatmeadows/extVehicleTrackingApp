using extVehicleTrackingAppAPIs.Data;

namespace extVehicleTrackingAppAPIs.Repositories
{
    public interface IVehicleService
    {
        public Task<int> AddVehicleAsync(ExtVehicle vehicle);
    }
}
