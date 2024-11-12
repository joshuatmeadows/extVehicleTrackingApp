using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using extVehicleTrackingApp.Data;

namespace extVehicleTrackingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<extVehicleTrackingApp.Data.ExtVehicle> ExtVehicle { get; set; } = default!;
    }
}
