using INVENTAR.IO.Data;
using INVENTAR.IO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace INVENTAR.IO.Pages.Asset
{
    public class AddModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddModel( AppDbContext context ) => _context = context;

        [BindProperty]
        public Assets Asset { get; set; } = default!;

        public Products Product { get; set; } = default!;

        public List<SelectListItem> Colaborators { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync( int? id )
        {
            if( id == null )
                return RedirectToPage( "./Index" );

            var product = await _context.Products.FirstOrDefaultAsync( e => e.ProductId == id );

            if( product == null )
                return RedirectToPage( "./Index" );

            else
            {
                Product = product;
                Colaborators = _context.Colaborators.Select( colaborators => new
                SelectListItem
                {
                    Text = colaborators.ColaboratorName,
                    Value = colaborators.ColaboratorId.ToString()

                } ).ToList();
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Asset.ProductId = id;
            ModelState.Remove( "Asset.Product" );
            ModelState.Remove( "Asset.Colaborator" );
            ModelState.Remove( "Asset.ColaboratorId" );

            if( !ModelState.IsValid )
            {
                Colaborators = _context.Colaborators.Select( colaborators => new
                SelectListItem
                {
                    Text = colaborators.ColaboratorName,
                    Value = colaborators.ColaboratorId.ToString()

                } ).ToList();
                return Page();
            }


            try
            {
                _context.Add( Asset );
                await _context.SaveChangesAsync();
            } catch
            {
                TempData[ "Message" ] = $"{Asset.AssetId} is already in use";
            }
            return RedirectToPage( "/View", new { id = id } );
        }
    }
}
