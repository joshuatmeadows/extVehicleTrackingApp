using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using extVehicleTrackingApp.Data;

namespace extVehicleTrackingApp.Pages.VehicleOrg
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
            return Page();
        }

        [BindProperty]
        public ExtVehicleOrg ExtVehicleOrg { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ExtVehicleOrgs.Add(ExtVehicleOrg);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
