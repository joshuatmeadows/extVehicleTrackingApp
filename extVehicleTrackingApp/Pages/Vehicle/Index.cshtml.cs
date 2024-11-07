using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using extVehicleTrackingApp.Data;
using System.Net.Http;

namespace extVehicleTrackingApp.Pages.Vehicle
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IList<ExtVehicle> ExtVehicle { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(string OrgId)
        {
            if (string.IsNullOrEmpty(OrgId))
            {
                return Page(); // Return the page without API data if queryParam is empty
            }

            try
            {
                // Replace with the actual endpoint URL and adjust query parameters as needed
                string requestUrl = $"https://localhost:7099/api/Vehicle/getallbyorg?OrgId={Uri.EscapeDataString(OrgId)}";

                // Send the request to the external API
                ExtVehicle = await _httpClient.GetFromJsonAsync<IList<ExtVehicle>>(requestUrl) ?? new List<ExtVehicle>();
            }
            catch (HttpRequestException e)
            {
                // Handle any HTTP request errors here
                Console.WriteLine($"Request error: {e.Message}");
                // Optionally, log the error or provide a user-friendly message on the page
            }

            return Page();
        }
    }
}
