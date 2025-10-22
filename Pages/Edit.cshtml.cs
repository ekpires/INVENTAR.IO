using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace INVENTAR.IO.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Products Product { get; set; } = default!;
        
        public EditModel(AppDbContext context)
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
            {
                Product = product;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return Page();

            Product.ProductName = Product.ProductName.ToUpper();
            Product.ProductModel = Product.ProductModel.ToUpper();

            try
            {
                _context.Attach(Product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                TempData["Message"] = $"{Product.ProductModel} model already exists";
            }
            return RedirectToPage("./Index");
        }
    }
}
