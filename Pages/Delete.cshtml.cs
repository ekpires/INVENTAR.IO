using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace INVENTAR.IO.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Products Product { get; set; } = default!;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return RedirectToPage("./Index");

            var product = await _context.Products.FirstOrDefaultAsync(e => e.ProductId == id);

            if (product == null)
                return RedirectToPage("./Index");
            else
                Product = product;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return RedirectToPage("./Index");

            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                Product = product;
                TempData["Message"] = $"{Product.ProductName}-{Product.ProductModel} has been deleted";
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");

        }
    }
}
