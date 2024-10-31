using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using extVehicleTrackingApp.Data;

namespace extVehicleTrackingApp.Pages.VehicleOrg
{
    public class IndexModel : PageModel
    {
        private readonly extVehicleTrackingApp.Data.VehichleTrackingDbContext _context;

        public IndexModel(extVehicleTrackingApp.Data.VehichleTrackingDbContext context)
        {
            _context = context;
        }

        public IList<ExtVehicleOrg> ExtVehicleOrg { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ExtVehicleOrg = await _context.ExtVehicleOrgs.ToListAsync();
        }
    }
}
