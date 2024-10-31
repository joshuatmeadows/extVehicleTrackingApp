using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using extVehicleTrackingApp.Data;

namespace extVehicleTrackingApp.Pages.Vehicle
{
    public class EditModel : PageModel
    {
        private readonly extVehicleTrackingApp.Data.ApplicationDbContext _context;

        public EditModel(extVehicleTrackingApp.Data.ApplicationDbContext context)
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

            var extvehicle =  await _context.ExtVehicle.FirstOrDefaultAsync(m => m.Id == id);
            if (extvehicle == null)
            {
                return NotFound();
            }
            ExtVehicle = extvehicle;
           ViewData["OrgId"] = new SelectList(_context.Set<ExtVehicleOrg>(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ExtVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtVehicleExists(ExtVehicle.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExtVehicleExists(int id)
        {
            return _context.ExtVehicle.Any(e => e.Id == id);
        }
    }
}
