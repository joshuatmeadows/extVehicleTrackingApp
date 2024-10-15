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
    }
}
