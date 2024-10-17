using extVehicleTrackingAppAPIs.Data;

namespace extVehicleTrackingAppAPIs.Repositories
{
    public interface IVehicleService
    {
        Task<int> VehicleAdd(ExtVehicle vehicle);
        Task<IEnumerable<ExtVehicle>> VehicleGetAllByOrg(int OrgId);
        Task<int> VehicleUpdate(ExtVehicle vehicle);
    }
}
