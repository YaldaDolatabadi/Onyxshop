using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onyxshop.Models;
using Onyxshop.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Onyxshop.Pages.Admin
{
    public class EditModel : PageModel
    {
        private OnyxContext _context;
        public EditModel(OnyxContext context)
        {
            _context= context;
        }

        [BindProperty]
        public AddorEditProductViewmodel producttoedit { get; set; }

        public void OnGet(int id)
        {
            producttoedit=_context.products.Include(p=>p.SabadItem)
                .Where(p=>p.Id==id)
                .Select(s=>new AddorEditProductViewmodel
                {
                    Id=s.Id,
                    name=s.Name,
                    description=s.description,
                    quantityinstock=s.SabadItem.quantityinstock,
                    price=s.SabadItem.price
                }).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var product = _context.products.Find(producttoedit.Id);
            
            var item = _context.sabadItems.Find(product.sabaditemid);

            
            product.Name = producttoedit.name;
            product.description=producttoedit.description;
            product.vazn=producttoedit.vazn;
            item.price = producttoedit.price;
            item.quantityinstock = producttoedit.quantityinstock;
            _context.SaveChanges();
            return RedirectToPage("Index");
        }

    }
}
