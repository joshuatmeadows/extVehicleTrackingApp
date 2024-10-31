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
    public class IndexModel : PageModel
    {
        private readonly extVehicleTrackingApp.Data.ApplicationDbContext _context;

        public IndexModel(extVehicleTrackingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ExtVehicle> ExtVehicle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ExtVehicle = await _context.ExtVehicle
                .Include(e => e.Org).ToListAsync();
        }
    }
}
