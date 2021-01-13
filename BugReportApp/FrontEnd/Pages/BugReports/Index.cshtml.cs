using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages.BugReports
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<BugReport> BugReports { get; set; }

        public async Task OnGet()
        {
            BugReports = new List<BugReport>()
            {
                new BugReport(){ ID = 1, Title = "Bug 1", Description = "Test for bug 1", },
                new BugReport(){ ID = 2, Title = "Bug 2", Description = "Test for bug 2", },
                new BugReport(){ ID = 3, Title = "Bug 3", Description = "Test for bug 3", },
                new BugReport(){ ID = 4, Title = "Bug 4", Description = "Test for bug 4", }
            };

            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://backend/api/BugReports");
                var response = await client.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();
                ViewData["Message"] += " and " + responseString;
            }
        }
    }
}
