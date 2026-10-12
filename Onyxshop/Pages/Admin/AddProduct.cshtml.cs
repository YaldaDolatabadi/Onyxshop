using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onyxshop.Data;
using Onyxshop.Models;

namespace Onyxshop.Pages.Admin
{
    public class AddProductModel : PageModel
    {
        public IEnumerable<product> Pro { get; set; }
        private OnyxContext _context;
        public AddProductModel(OnyxContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            var Pro = _context.products;

        }

    }
}
