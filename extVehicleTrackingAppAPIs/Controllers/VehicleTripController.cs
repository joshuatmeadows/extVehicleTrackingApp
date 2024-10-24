using extVehicleTrackingAppAPIs.Repositories;
using extVehicleTrackingAppAPIs.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace extVehicleTrackingAppAPIs.Controllers
{
    public class VehicleTripController : ControllerBase
    {
        private readonly IVehicleTripService VehicleTripService;
        public VehicleTripController(IVehicleTripService vehicleTripService)
        {
            this.VehicleTripService = vehicleTripService;
        }
        [HttpGet("getbyvehicle")]
        public async Task<IEnumerable<ExtVehicleTrip>> VehicleTripGetByVehicle(int vehicleId)
        {
            try
            {
                var response = await VehicleTripService.VehicleTripGetByVehicle(vehicleId);
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
    }
}
