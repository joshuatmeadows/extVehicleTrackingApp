using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using extVehicleTrackingApp.Data;

namespace extVehicleTrackingApp.Pages.Vehicle
{
    public class DetailsModel : PageModel
    {
        private readonly extVehicleTrackingApp.Data.ApplicationDbContext _context;

        public DetailsModel(extVehicleTrackingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ExtVehicle ExtVehicle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extvehicle = await _context.ExtVehicle.FirstOrDefaultAsync(m => m.Id == id);
            if (extvehicle == null)
            {
                return NotFound();
            }
            else
            {
                ExtVehicle = extvehicle;
            }
            return Page();
        }
    }
}
