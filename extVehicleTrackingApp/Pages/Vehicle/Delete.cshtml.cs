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
    public class DeleteModel : PageModel
    {
        private readonly extVehicleTrackingApp.Data.ApplicationDbContext _context;

        public DeleteModel(extVehicleTrackingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extvehicle = await _context.ExtVehicle.FindAsync(id);
            if (extvehicle != null)
            {
                ExtVehicle = extvehicle;
                _context.ExtVehicle.Remove(ExtVehicle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
