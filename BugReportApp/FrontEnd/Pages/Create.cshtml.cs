using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FrontEnd.Pages.BugReports
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public BugReport BugReport { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                "http://backend/api/BugReports", BugReport);
                response.EnsureSuccessStatusCode();
            }
            return RedirectToPage("./Index");
        }
    }
}
