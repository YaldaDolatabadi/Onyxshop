using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onyxshop.Data;
using Onyxshop.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Onyxshop.Pages.Admin
{
    public class deleteModel : PageModel
    {
        private OnyxContext _context;
        public deleteModel( OnyxContext context)
        {
            _context=context;
        }

        [BindProperty]
        public product producttodelete { get; set; }
        public void OnGet(int id)
        {


            producttodelete =_context.products
                .FirstOrDefault(p => p.Id == id);
            
            
                  
        }

        public IActionResult OnPost()
        {

            //////ولید نمیشه
            //if (!ModelState.IsValid)
            //{
            //    var message = string.Join(" | ", ModelState.Values
            //                               .SelectMany(v => v.Errors)
            //                               .Select(e => e.ErrorMessage));
            //    return Page();
            //}

            var product = _context.products.Find(producttodelete.Id);
           
            var item = _context.sabadItems.Find(product.sabaditemid);



            _context.Remove(product);
            _context.Remove(item);
              
             
               _context.SaveChanges();

            return RedirectToPage("Index");
        }

    }
}
