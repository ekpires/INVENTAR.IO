using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace INVENTAR.IO.Pages
{
    public class ViewModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Products Product { get; set; } = default!;

        public ViewModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return RedirectToPage("./Index");

            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return RedirectToPage("./Index");
            else 
            {
                Product = product;
                return Page();
            }
        }
    }
}
