using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace INVENTAR.IO.Pages.Colaborator
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Colaborators Colaborators { get; set; } = default!;

        public IList<Departments> Departments { get; set; } = default!;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return RedirectToPage("./Index");

            var colaborators = await _context.Colaborators.FirstOrDefaultAsync(e => e.ColaboratorId == id);

            if (colaborators == null)
                return RedirectToPage("./Index");

            else
            {
                Colaborators = colaborators;
                Departments = await _context.Departments.ToListAsync();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return Page();

            var colaborators = await _context.Colaborators.FindAsync(id);

            if (colaborators == null)
                return Page();
            else
            {
                Colaborators = colaborators;
                TempData["Message"] = $"{Colaborators.ColaboratorName} has been deleted";
                _context.Colaborators.Remove(Colaborators);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
    }
}
