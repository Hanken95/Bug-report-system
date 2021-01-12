using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Movie.Add(Movie);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
