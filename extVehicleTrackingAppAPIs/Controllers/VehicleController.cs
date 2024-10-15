using Microsoft.AspNetCore.Mvc;
using extVehicleTrackingAppAPIs.Data;
using extVehicleTrackingAppAPIs.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace extVehicleTrackingAppAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService VehicleService;
        public VehicleController(IVehicleService VehicleService)
        {
            this.VehicleService = VehicleService;
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
                var response = await VehicleService.AddVehicleAsync(vehicle);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
    }
}
