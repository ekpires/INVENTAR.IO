using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace INVENTAR.IO.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public Products Product { get; set; } = default!;

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            Product.ProductName = Product.ProductName.ToUpper();
            Product.ProductModel = Product.ProductModel.ToUpper();
            try
            {
                _context.Products.Add(Product);
                await _context.SaveChangesAsync();
            }
            catch
            {
                TempData["Message"] = $"{Product.ProductName} already exists";
            }
            return RedirectToPage("./Index");
        }
    }
}
