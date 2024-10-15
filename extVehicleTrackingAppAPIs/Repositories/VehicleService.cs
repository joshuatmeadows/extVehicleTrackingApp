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
        public async Task<int> AddVehicleAsync(ExtVehicle vehicle)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@VehicleName", vehicle.Model));
            parameter.Add(new SqlParameter("@VehicleVin", vehicle.Vin));
            parameter.Add(new SqlParameter("@VehiclePlate", vehicle.Plate));
            parameter.Add(new SqlParameter("@VehicleOrgId", vehicle.OrgId));
            parameter.Add(new SqlParameter("@VehicleYear", vehicle.Year));
            parameter.Add(new SqlParameter("@VehicleInspection", vehicle.Inspection));
            parameter.Add(new SqlParameter("@VehicleSurplus", vehicle.Surplus));
            parameter.Add(new SqlParameter("@VehicleEmail", vehicle.Email));
            parameter.Add(new SqlParameter("@VehicleFilepath", vehicle.Filepath));
            return await _dbContext.Database.ExecuteSqlRawAsync("EXEC spVehicleAdd @VehicleName, @VehicleVin, @VehiclePlate, @VehicleOrgId, @VehicleYear, @VehicleInspection, @VehicleSurplus, @VehicleEmail, @VehicleFilepath", parameter.ToArray());


        }
    }
}
