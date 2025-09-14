using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace INVENTAR.IO.Pages.User.Department
{
    public class EditModel : PageModel
    {
        public readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Departments Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return RedirectToPage("./Index");

            var departments = await _context.Departments.FirstOrDefaultAsync(e => e.DepartmentId == id);

            if (departments == null)
                return RedirectToPage("./Index");
            else
            {
                Department = departments;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            Department.DepartmentName = Department.DepartmentName.ToUpper();
            try
            {
                _context.Departments.Update(Department);
                await _context.SaveChangesAsync();
            }
            catch
            {
                TempData["Message"] = $"{Department.DepartmentName} already exists";
            }
            return RedirectToPage("./Index");
        }
    }
}
