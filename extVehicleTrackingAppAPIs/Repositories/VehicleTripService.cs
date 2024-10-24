using extVehicleTrackingAppAPIs.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace extVehicleTrackingAppAPIs.Repositories
{
    public class VehicleTripService: IVehicleTripService
    {
        private readonly DbContextClass _dbContext;
        public VehicleTripService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ExtVehicleTrip>> VehicleTripGetByVehicle(int vehicleId)
        {
            var param = new SqlParameter("@vehicleId", vehicleId);

            var tripDetails = await Task.Run(() => _dbContext.ExtVehicleTrip.FromSqlRaw(@"exec spVehicleTripGetByVehicle @vehicleId", param).ToListAsync());
            return tripDetails;
        }
    }
}
