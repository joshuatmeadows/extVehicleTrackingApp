using extVehicleTrackingAppAPIs.Data;
using Microsoft.EntityFrameworkCore;
namespace extVehicleTrackingAppAPIs.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<ExtVehicle> ExtVehicle { get; set; }
        public DbSet<ExtVehicleTrip> ExtVehicleTrip { get; set; }
    }
}