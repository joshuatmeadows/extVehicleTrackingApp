using extVehicleTrackingAppAPIs.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace extVehicleTrackingAppAPIs.Repositories
{
    public class VehicleService : IVehicleService
    {
        private readonly DbContextClass _dbContext;
        public VehicleService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> VehicleAdd(ExtVehicle vehicle)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Model", vehicle.Model));
            parameter.Add(new SqlParameter("@Vin", vehicle.Vin));
            parameter.Add(new SqlParameter("@Plate", vehicle.Plate));
            parameter.Add(new SqlParameter("@OrgId", vehicle.OrgId));
            parameter.Add(new SqlParameter("@Year", vehicle.Year));
            parameter.Add(new SqlParameter("@Inspection", vehicle.Inspection));
            parameter.Add(new SqlParameter("@Surplus", vehicle.Surplus));
            parameter.Add(new SqlParameter("@Email", vehicle.Email));
            parameter.Add(new SqlParameter("@Filepath", vehicle.Filepath));
            return await _dbContext.Database.ExecuteSqlRawAsync("exec spVehicleAdd @Model, @Vin, @Plate, @OrgId, @Year, @Inspection, @Surplus, @Email, @Filepath", parameter.ToArray());
        }

        public async Task<IEnumerable<ExtVehicle>> VehicleGetAllByOrg(int OrgId)
        {
            var param = new SqlParameter("@OrgId", OrgId);
            var vehicleDetails = await Task.Run(() => _dbContext.ExtVehicle
                .FromSqlRaw(@"exec spVehicleGetAllByOrg @OrgId", param).ToListAsync());
            return vehicleDetails;
        }

        public async Task<int> VehicleUpdate(ExtVehicle vehicle)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Id", vehicle.Id));
            parameter.Add(new SqlParameter("@Model", vehicle.Model));
            parameter.Add(new SqlParameter("@Vin", vehicle.Vin));
            parameter.Add(new SqlParameter("@Plate", vehicle.Plate));
            parameter.Add(new SqlParameter("@OrgId", vehicle.OrgId));
            parameter.Add(new SqlParameter("@Year", vehicle.Year));
            parameter.Add(new SqlParameter("@Inspection", vehicle.Inspection));
            parameter.Add(new SqlParameter("@Surplus", vehicle.Surplus));
            parameter.Add(new SqlParameter("@Email", vehicle.Email));
            parameter.Add(new SqlParameter("@Filepath", vehicle.Filepath));
            return await _dbContext.Database.ExecuteSqlRawAsync("exec spVehicleUpdate @Id, @Model, @Vin, @Plate, @OrgId, @Year, @Inspection, @Surplus, @Email, @Filepath", parameter.ToArray());
        }
        // this is a method to delete vehicles from the database.
        public async Task<int> VehicleDelete(int vehicleId)
        {
            var param = new SqlParameter("@vehicle_id", vehicleId);
            return await _dbContext.Database.ExecuteSqlRawAsync("exec spVehicleDelete @vehicle_id", param);

        }
    }
}
