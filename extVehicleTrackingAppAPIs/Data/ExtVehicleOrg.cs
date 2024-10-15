using System;
using System.Collections.Generic;

namespace extVehicleTrackingAppAPIs.Data;

public partial class ExtVehicleOrg
{
    public int Id { get; set; }

    public string? OrgName { get; set; }

    public virtual ICollection<ExtVehicle> ExtVehicles { get; set; } = new List<ExtVehicle>();
}
