using Microsoft.AspNetCore.Mvc;
using Onyxshop.Data;
using Microsoft.EntityFrameworkCore;
using Onyxshop.Models;

namespace Onyxshop.Controllers
{
    public class ProductsController : Controller
    {
        OnyxContext _context;
        
        public ProductsController(OnyxContext context)
        {
            _context = context;
        }

        //روت میدیم که اگر کاربر دلش خواست
       [Route("/Group/{id}")]
        public IActionResult showproductbygroup(int id)
        {
            //برای title صفحه
            //یک ویوبگ میفرستم 
            Category c = _context.categories.SingleOrDefault(c=>c.Id==id);
            ViewBag.tit = c.Name;
            
            //پروداکت هایی را میخوام که کتگوریشون آیدی ورودی باشه
            var products= _context.categoryToProducts
                .Where(c=>c.CategoryId==id).Include(c=>c.product)
                .Select(c=>c.product).ToList();

            
                
            return View(products);
        }
    }
}
