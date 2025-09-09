using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace INVENTAR.IO.Pages.User.Department
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Departments Department { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
                return Page();

            //add value to db
            return RedirectToPage(/*"/User"*/"/Index", new { Department });
        }
    }
}
