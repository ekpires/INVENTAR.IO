using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace INVENTAR.IO.Pages.Colaborator
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Colaborators Colaborator { get; set; } = default!;
        public List<SelectListItem> Departments { get; set; } = default!;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return RedirectToPage("./Index");

            var colaborator = await _context.Colaborators.FirstOrDefaultAsync(e => e.ColaboratorId == id);

            if (colaborator == null)
                return RedirectToPage("./Index");
            else
            {
                Colaborator = colaborator;
                Console.WriteLine(Colaborator.DepartmentId);
                Departments = _context.Departments.Select(departments =>
                new SelectListItem
                {
                    Text = departments.DepartmentName,
                    Value = departments.DepartmentId.ToString()

                }).ToList();
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            Colaborator.ColaboratorName = Colaborator.ColaboratorName.ToUpper();
            Colaborator.ColaboratorEmail = Colaborator.ColaboratorEmail.ToLower();

            try
            {
                Console.WriteLine(Colaborator.DepartmentId);
                _context.Colaborators.Update(Colaborator);
                _context.Attach(Colaborator).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                TempData["Message"] = $"{Colaborator.ColaboratorName} already exists";
            }
            return RedirectToPage("./Index");
        }
    }
}
