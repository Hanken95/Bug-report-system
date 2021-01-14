using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace FrontEnd.Pages.BugReports
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IList<BugReport> BugReports { get; set; }

        public async Task OnGet()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://backend/api/BugReport");
                var response = await client.SendAsync(request);
                if (response != null)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    JArray a = JArray.Parse(responseString);
                    BugReports = a.ToObject<IList<BugReport>>();
                }
            }
        }
    }
}
