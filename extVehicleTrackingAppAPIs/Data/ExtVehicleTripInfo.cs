using System;
using System.Collections.Generic;

namespace extVehicleTrackingAppAPIs.Data;

public partial class ExtVehicleTripInfo
{
    public int Id { get; set; }

    public int TripId { get; set; }

    public int Type { get; set; }

    public DateTime Ts { get; set; }

    public int Mileage { get; set; }

    public decimal? FuelGallons { get; set; }

    public decimal? FuelTotalCost { get; set; }

    public string? Filepath { get; set; }

    public virtual ExtVehicleTrip Trip { get; set; } = null!;
}
