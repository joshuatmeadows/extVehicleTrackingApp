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
        [HttpGet("getallbyorg")]
        public async Task<IEnumerable<ExtVehicle>> VehicleGetAllByOrg(int OrgId)
        {
            try
            {
                var response = await VehicleService.VehicleGetAllByOrg(OrgId);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updatevehicle")]
        public async Task<IActionResult> VehicleUpdate(ExtVehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await VehicleService.VehicleUpdate(vehicle);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("deletevehicle")]
        public async Task<IActionResult> VehicleDelete(int vehicleId)
        {
            var response = await VehicleService.VehicleDelete(vehicleId);
            return Ok(response);
        }

    }
}
