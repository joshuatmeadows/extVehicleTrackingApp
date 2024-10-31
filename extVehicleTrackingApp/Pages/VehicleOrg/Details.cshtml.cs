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
    public class DetailsModel : PageModel
    {
        private readonly extVehicleTrackingApp.Data.VehichleTrackingDbContext _context;

        public DetailsModel(extVehicleTrackingApp.Data.VehichleTrackingDbContext context)
        {
            _context = context;
        }

        public ExtVehicleOrg ExtVehicleOrg { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extvehicleorg = await _context.ExtVehicleOrgs.FirstOrDefaultAsync(m => m.Id == id);
            if (extvehicleorg == null)
            {
                return NotFound();
            }
            else
            {
                ExtVehicleOrg = extvehicleorg;
            }
            return Page();
        }
    }
}
