using System;
using System.Collections.Generic;

namespace extVehicleTrackingApp.Data;

public partial class ExtVehicleTrip
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public int UserId { get; set; }

    public string Department { get; set; } = null!;

    public string? TravelReason { get; set; }

    public string? AdditionalTravelers { get; set; }

    public string? FundingSource { get; set; }

    public virtual ICollection<ExtVehicleTripInfo> ExtVehicleTripInfos { get; set; } = new List<ExtVehicleTripInfo>();

    public virtual ExtVehicle Vehicle { get; set; } = null!;
}
