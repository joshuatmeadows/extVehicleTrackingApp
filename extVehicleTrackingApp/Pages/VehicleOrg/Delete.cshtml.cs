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
    public class DeleteModel : PageModel
    {
        private readonly extVehicleTrackingApp.Data.VehichleTrackingDbContext _context;

        public DeleteModel(extVehicleTrackingApp.Data.VehichleTrackingDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extvehicleorg = await _context.ExtVehicleOrgs.FindAsync(id);
            if (extvehicleorg != null)
            {
                ExtVehicleOrg = extvehicleorg;
                _context.ExtVehicleOrgs.Remove(ExtVehicleOrg);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
