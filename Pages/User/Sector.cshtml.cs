using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace INVENTAR.IO.Pages.User
{
    public class SectorModel : PageModel
    {
        [BindProperty]
        public string Sector { get; set; }

        public void OnGet()
        {
            //get sector names from db and display in a list
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
                return Page();

            //add value to db
            return RedirectToPage(/*"/User"*/"/Index", new { Sector });
        }
    }
}
