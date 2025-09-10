using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace INVENTAR.IO.Pages.User.Department
{
    public class CreateModel : PageModel
    {

        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Departments Department { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
                return Page();

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index", new { Department });
        }
    }
}
