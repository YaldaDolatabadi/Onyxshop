using System.ComponentModel.DataAnnotations.Schema;

namespace Onyxshop.Models
{
    public class product
    {

        //برای استفاده از لیست باید نمونه سازی کرد توسط dependency injection
        //public product()
        //{
        //    Categories = new List<Category>();
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal vazn { get; set; }
        public string description { get; set; }
        //public List<Category> Categories { get; set; } //محصول میتواند در دسته های مختلف باشد 

        public int sabaditemid { get; set; } //هرمحصول یک آیتم خرید دارد(foreignkey)
        public ICollection<CategoryToProduct> categoryToProducts { get; set; }
        

        //navigation

        [ForeignKey("sabaditemid")]
        public SabadItem SabadItem { get; set; } //relation
        public List<OrderDetails> orderDetails { get; set; }

    }
}
