using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Pages
{
    public class DeleteModel : PageModel
    {

        [BindProperty]
        public BugReport BugReport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await SetCurrentBugReport(id);

            if (BugReport == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //await SetCurrentBugReport(id);

            if (BugReport != null)
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    var requestUri = new Uri("http://backend/api/BugReport/" + id);
                    var response = await client.DeleteAsync(requestUri);
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task SetCurrentBugReport(int? id)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://backend/api/BugReport/" + id);
                var response = await client.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();
                BugReport = JsonConvert.DeserializeObject<BugReport>(responseString);
            }
        }
    }
}
