using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using extVehicleTrackingApp.Data;

namespace extVehicleTrackingApp.Pages.Vehicle
{
    public class CreateModel : PageModel
    {
        private readonly extVehicleTrackingApp.Data.VehichleTrackingDbContext _context;

        public CreateModel(extVehicleTrackingApp.Data.VehichleTrackingDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrgId"] = new SelectList(_context.Set<ExtVehicleOrg>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ExtVehicle ExtVehicle { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ExtVehicles.Add(ExtVehicle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
