using Microsoft.AspNetCore.Mvc;
using Onyxshop.Models;
using System.Diagnostics;
using Onyxshop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Onyxshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private static Cart _cart=new Cart();

        //هرجا با کانتکست کار داشتم از این میخوام
        private OnyxContext _context;

        public HomeController(ILogger<HomeController> logger, OnyxContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products=_context.products.ToList();
            return View(products);
        }

    [Route("contactus")]
        public IActionResult contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //اکشن زیر برای نمایش جزئیات محصول است
        public IActionResult details(int id)
        {
            //1
            var product = _context.products
                .Include(c=>c.SabadItem) //اینو نذاشته بودم وقتی رو دکمه جزییات زدم به خطا خوردم. چون وقتی محصول رو میاری باید آیتمشم باهاش بیاری که ازش قیمت و جزییاتشو دربیاری و این درواقع نویگیشن ورابطشه
                .FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            //2
            var categories = _context.categoryToProducts.Where(x => x.ProductId == id).Select(t=>t.category).ToList();
            
            //3=1+2
            var vm = new detailsviewmodel
            {
                product = product,
                categories = categories,

            };
            //الان هم میخوام محصول رو به ویو ببرم هم کتگوریاشو پس ویومدل میسازم
            
                return View(vm);
           
        }

        //اکشن زیر جهت اضافه کردن به سبد خرید است
        [Authorize]
        public IActionResult addtosabad(int itemid)
        {
            ////  ایمان مدائنی یه جوردیگه رفت جلو درواقع پروداکتو کشید بیرون با آیتمش بعد از آیتمش استفاده کرد 
            //var item= _context.sabadItems.Include(i=>i.product).
            //    FirstOrDefault(x => x.Id == sabaditemid);
            //کار بدی نکردی ولی از این به بعد چون دیگه آیتم و کارت آیتم نداریم و درواقع اردر داریم که با پروداکت در ارتباطه ما هم با پروداکت کار میکنیم
            var item = _context.products.Include(c=>c.SabadItem).FirstOrDefault(c => c.Id == itemid);
            if ( item!= null)
            {
                //      var cartitem = new CartItem()
                //      {
                //          SabadItem = item,
                //          quantityincart = 1,

                //      };
                ////این کارت آیتم اضافه میشه به لیست کارت آیتم های کارتی که بالا بصورت استاتیک تعریف کردیم
                //      _cart.addItem(cartitem);

                int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString()); //برای پیدا کردن یوزر لاگین شده
                var order = _context.orders.FirstOrDefault(o => o.UserId == userid && !o.isfinally); //ببینیم اصلا فاکتور بسته نشده ای براش وجود داره یا نه
                if (order != null)
                {
                    var d = _context.orderDetails.FirstOrDefault(d => d.order.UserId == userid && d.ProductId == itemid);
                    if (d != null)
                        d.count += 1;
                    else
                    {
                        var ditem = new OrderDetails
                        {
                            OrderId = order.OrderId,
                            ProductId = itemid,
                            price = item.SabadItem.price,
                            count = 1,
                        };
                        _context.orderDetails.Add(ditem);
                    }

                }
                else //if order is null
                {
                    order = new Order
                    {
                        UserId = userid,
                        Createdate = DateTime.Now,
                        isfinally = false,
                    };
                    _context.orders.Add(order);
                    _context.SaveChanges();
                    var ditem = new OrderDetails
                    {
                        OrderId = order.OrderId,
                        ProductId = itemid,
                        price = item.SabadItem.price,
                        count = 1,
                    };
                    _context.orderDetails.Add(ditem);
                }
                _context.SaveChanges();

            }
            return RedirectToAction("showcart");
        }

        // یه اکشن هم نیاز دارم که سبد (کارت آیتم ها رو) نشونم بده

        [Authorize]
        public IActionResult showcart()
        {
            ////مدل صفحه رو نیو میکنی دیگه
            //var cartview = new Cartviewmodel()
            //{
            //    cartitems = _cart.cartItems,
            //    totalmablagh= _cart.cartItems.Sum(c=>c.gettotalprice()),
            //};

            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString()); //برای پیدا کردن یوزر لاگین شده
            //کاربر لاگین شده رو داریم حالا چیزی که باید به 
            //صفحه ببریم فاکتور و ریز فاکتور و محصولاتش است
            var order=_context.orders.Where(d => d.UserId == userid &&!d.isfinally)
                .Include(o=>o.details).ThenInclude(d=>d.product).FirstOrDefault();
           
            //if (order!= null) این چیزا رو تو ویو کنترل میکنیم 

            return View(order);
        }

        [Authorize]
        public IActionResult removefromcart(int cartitemid) //ورودی درواقع آی دی دیتیله
        {
            //_cart.removeItem(cartitemid);

            var odtoremove = _context.orderDetails.FirstOrDefault(o => o.DetailId == cartitemid);
            _context.Remove(odtoremove);
            _context.SaveChanges();
            return RedirectToAction("showcart");
        }

    }
}