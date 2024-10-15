using System;
using System.Collections.Generic;

namespace extVehicleTrackingAppAPIs.Data;

public partial class ExtVehicleOrgPermission
{
    public int Id { get; set; }

    public int OrgId { get; set; }

    public int UserId { get; set; }

    public int PermLevel { get; set; }

    public virtual ExtVehicleOrg Org { get; set; } = null!;
}
