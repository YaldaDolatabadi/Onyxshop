using Microsoft.EntityFrameworkCore;
using Onyxshop.Models;

namespace Onyxshop.Data;

public class OnyxContext : DbContext
{
    public OnyxContext(DbContextOptions<OnyxContext> options) : base(options)
    {

    }

    public DbSet<Category> categories { get; set; }
    public DbSet<product> products { get; set; }
    public DbSet<CategoryToProduct> categoryToProducts { get; set; }
    public DbSet<SabadItem> sabadItems { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<Order> orders { get; set; }
    public DbSet<OrderDetails> orderDetails { get; set; }

    //public DbSet<> MyProperty { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryToProduct>().HasKey(k => new { k.CategoryId, k.ProductId });
        ////هرچند اکثر مواقع خود انتیتی فریمورک با هوشمندی روابط بین مدل ها را تعیین میکند اما استاندارد تر این است که ما هم توسط
        //// فلوئنت ای پی آی آنها را تعیین کنیم این یک شیوه از فلوئنت ای پی آی است 



        //modelBuilder.Entity<product>(
        //    P => {
        //        P.HasKey(Q => Q.Id); // p namayandeye product va q namayande p ast.
        //        P.OwnsOne<SabadItem>(V => V.SabadItem); //پی دارد بعنوان نماینده پروداکت عمل میکند. میگه توسط فیلد سبد آیتم با جدول سبد آیتم رابطه یک به یک دارد 
        //        P.HasOne<SabadItem>(V => V.SabadItem).WithOne(V => V.product).HasForeignKey<SabadItem>(v => v.Id); //. یعنی رابطه از جدول دیگر گرفته. اینم طرف دوم خط قبلیه
            
        //         }

        //    );
        modelBuilder.Entity<SabadItem>(
            i =>
            {
                i.HasKey(Q => Q.Id);
                i.Property(j => j.price).HasColumnType("money");
            }
            );



        #region seeddata
        modelBuilder.Entity<Category>().HasData
            (
            new Category()
            {
                Id = 1,
                Name = "گردنبند ",
                decription = "گردنبند های طلا و نقره در مدل ها و سبک های مختلف "
            },
           new Category()
           {
               Id = 2,
               Name = "النگو ",
               decription = "النگو های طلا و نقره در مدل ها و سبک های مختلف "
           },
           new Category()
           {
               Id = 3,
               Name = "دستبند ",
               decription = "دستبند های طلا و نقره در مدل ها و سبک های مختلف "
           },
           new Category()
           {
               Id = 4,
               Name = "انگشتر",
               decription = "انگشتر های طلا و نقره در مدل ها و سبک های مختلف "
           }

            );

        modelBuilder.Entity<SabadItem>().HasData(
            new SabadItem() { Id = 1, price = 5000000.0m, quantityinstock = 1 },
            new SabadItem() { Id = 2, price = 1000000.0m, quantityinstock = 1 },
            new SabadItem() { Id = 3, price = 450000.0m, quantityinstock=2 }
            ) ;

        modelBuilder.Entity<product>().HasData(
            new product() {
            Id = 1, 
            sabaditemid = 1,
            Name="زنجیر ساده طلا",
            description ="زنجیر ساده طلا باریک 23 سانتیمتری ",
            vazn=4

            },
            new product()
            {
                Id = 2,
                sabaditemid = 2,
                Name = "رینگ ساده زنانه طلا",
                description = "رینگ ساده زنانه طلای زرد پهنای متوسط",
                vazn = 4.5m

            },

            new product()
            {
                Id = 3,
                sabaditemid = 3,
                Name = " A گردنبند",
                description = "پلاک زنانه حرف A بهمراه زنجیر",
                vazn = 2.34m

            }
            );

        modelBuilder.Entity<CategoryToProduct>().HasData(
            new CategoryToProduct() { CategoryId=1,ProductId=1},
            new CategoryToProduct() { CategoryId = 4, ProductId = 2 },
            new CategoryToProduct() { CategoryId = 1, ProductId = 3 }
            );




    #endregion
        base.OnModelCreating(modelBuilder);
    }


}

