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
        public List<BugReport> BugReports { get; set; }

        public void OnGet()
        {
            BugReports = new List<BugReport>()
            {
                new BugReport(){ ID = 1, Title = "Bug 1", Description = "Test for bug 1", Status = Status.Open },
                new BugReport(){ ID = 2, Title = "Bug 2", Description = "Test for bug 2", Status = Status.Closed },
                new BugReport(){ ID = 3, Title = "Bug 3", Description = "Test for bug 3", Status = Status.Closed },
                new BugReport(){ ID = 4, Title = "Bug 4", Description = "Test for bug 4", Status = Status.Open }
            };
        }
    }
}
