using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace INVENTAR.IO.Pages.Colaborator
{
    public class CreateModel : PageModel
    {

        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Departments { get; set; } = new();

        public IActionResult OnGet()
        {

            Departments = _context.Departments.Select(departments => new
            SelectListItem
            {
                Text = departments.DepartmentName,
                Value = departments.DepartmentId.ToString()

            }).ToList();

            return Page();
        }

        [BindProperty]
        public Colaborators Colaborator { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {

            ModelState.Remove("Colaborator.Department");

            if (!ModelState.IsValid)
            {
                TempData["Message"] = "The Department field is required.";
                Departments = _context.Departments.Select(departments => new
                SelectListItem
                {
                    Text = departments.DepartmentName,
                    Value = departments.DepartmentId.ToString()

                }).ToList();

                return Page();
            }

            Colaborator.ColaboratorName = Colaborator.ColaboratorName.ToUpper();
            Colaborator.ColaboratorEmail = Colaborator.ColaboratorEmail.ToLower();
            
            try
            {
                _context.Colaborators.Add(Colaborator);
                await _context.SaveChangesAsync();
            }
            catch
            {
                TempData["Message"] = $"Another colaborator is using {Colaborator.ColaboratorEmail}";
            }

            return RedirectToPage("./Index");
        }
    }
}
