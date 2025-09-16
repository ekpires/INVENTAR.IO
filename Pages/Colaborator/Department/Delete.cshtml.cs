using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace INVENTAR.IO.Pages.User.Department
{
    public class DeleteModel : PageModel
    {

        private readonly AppDbContext _context;

        public DeleteModel( AppDbContext context ) => _context = context;

        public Departments Departments { get; set; }

        public async Task<IActionResult> OnGetAsync( int? id )
        {
            if( id == null )
                return RedirectToPage( "./Index" );

            var departments = await _context.Departments.FirstOrDefaultAsync( e => e.DepartmentId == id );

            if( departments == null )
                return RedirectToPage( "./Index" );
            else
                Departments = departments;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync( int? id )
        {
            if( id == null )
                return Page();

            var departments = await _context.Departments.FindAsync( id );

            if( departments == null )
                return Page();
            else
            {
                Departments = departments;
                TempData[ "Message" ] = $"{Departments.DepartmentName} has been deleted";
                _context.Departments.Remove( Departments );
                await _context.SaveChangesAsync();
                return RedirectToPage( "./Index" );
            }
        }
    }
}
