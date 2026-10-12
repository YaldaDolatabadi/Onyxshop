using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onyxshop.Models;
using Onyxshop.Data;
using Microsoft.EntityFrameworkCore;

namespace Onyxshop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private OnyxContext _context;
        //هر پراپرتی پابلیکی که در کد تعریف کنیم در ویوش بهش دسترسی داریم
        public IEnumerable<product> products { get; set; }

        [BindProperty]
        public AddorEditProductViewmodel newproduct { get; set; }

        public IndexModel(OnyxContext context )
        {
            _context = context;
            
        }
        public void OnGet()
        {
            products = _context.products.Include(p => p.SabadItem);
         
        }

        public IActionResult Onpost(AddorEditProductViewmodel newproduct)
        {
            try {
                if (!ModelState.IsValid)
                {
                    return Page();
                }


                SabadItem sabad = new SabadItem
                {
                    price = newproduct.price,
                    quantityinstock = newproduct.quantityinstock,
                };
                _context.Add(sabad);


                _context.SaveChanges();
                var product = new product
                {
                    Name = newproduct.name,
                    description = newproduct.description,
                    vazn = newproduct.vazn,
                    SabadItem = sabad
                };
                _context.Add(product);
                _context.SaveChanges();
                //product.sabaditemid = product.Id;
                //_context.SaveChanges();

                if (newproduct.picture?.Length > 0)
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                       "wwwroot",
                       "images",
                       product.Id + Path.GetExtension(newproduct.picture.FileName));
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        newproduct.picture.CopyTo(stream);
                    }
                }



                return RedirectToPage("Index");
            }
            catch(Exception e)
            {
                throw;
            }

   
        }

        //public IActionResult OnGetdelete(int id)
        //{
        //    var p = _context.products.Where(p => p.Id == id);
        //    var i = _context.sabadItems.Where(p => p.Id == id);
        //    _context.Remove(i);
        //    _context.Remove(p);
        //    _context.SaveChanges();
        //    return RedirectToPage("Index");
        //}
    }
}
