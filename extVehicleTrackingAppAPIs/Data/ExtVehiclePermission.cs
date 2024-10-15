using System;
using System.Collections.Generic;

namespace extVehicleTrackingAppAPIs.Data;

public partial class ExtVehiclePermission
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public int UserId { get; set; }

    public int PermLevel { get; set; }

    public virtual ExtVehicle Vehicle { get; set; } = null!;
}
