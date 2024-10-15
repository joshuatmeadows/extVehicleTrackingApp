using extVehicleTrackingAppAPIs.Repositories;
using extVehicleTrackingAppAPIs.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace extVehicleTrackingAppAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService VehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            this.VehicleService = vehicleService;
        }
        [HttpPost("addvehicle")]
        public async Task<IActionResult> AddVehicleAsync(ExtVehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await VehicleService.VehicleAdd(vehicle);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

    }
}
