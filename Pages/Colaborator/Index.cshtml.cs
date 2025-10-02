using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace INVENTAR.IO.Pages.User
{
    public class IndexModel : PageModel
    {

        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Colaborators> Colaborators { get; set; } = default!;
        public IList<Departments> Departments { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Colaborators = await _context.Colaborators.ToListAsync();
            Departments = await _context.Departments.ToListAsync();
        }
    }
}
