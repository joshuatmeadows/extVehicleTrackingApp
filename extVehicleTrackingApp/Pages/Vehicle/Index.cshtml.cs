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
            _httpClient=httpClient;
        }

        public IList<ExtVehicle> ExtVehicle { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(string OrgId)
        {
            if(string.IsNullOrEmpty(OrgId))
            {
                return Page();
            }

            try
            {
                // make the endpoint string we want to hit
                string requestUrl = $"https://localhost:7099/api/Vehicle/getallbyorg?OrgId={Uri.EscapeDataString(OrgId)}";

                // Send the GET request to the API
                ExtVehicle = await _httpClient.GetFromJsonAsync<IList<ExtVehicle>>(requestUrl) ?? new List<ExtVehicle>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return Page();
        }
    }
}
