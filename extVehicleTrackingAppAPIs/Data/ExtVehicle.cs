using System;
using System.Collections.Generic;

namespace extVehicleTrackingAppAPIs.Data;

public partial class ExtVehicle
{
    public int Id { get; set; }

    public string Model { get; set; } = null!;

    public string Vin { get; set; } = null!;

    public string Plate { get; set; } = null!;

    public int? OrgId { get; set; }

    public int Year { get; set; }

    public DateOnly? Inspection { get; set; }

    public bool? Surplus { get; set; }

    public string? Email { get; set; }

    public string? Filepath { get; set; }

    public virtual ICollection<ExtVehicleTrip> ExtVehicleTrips { get; set; } = new List<ExtVehicleTrip>();

    public virtual ExtVehicleOrg? Org { get; set; }
}
