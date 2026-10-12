using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onyxshop.Models
{
    public class OrderDetails
    {
        [Key]
        public int DetailId { get; set; }
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        //واسه این که قیمت محصول عوض نشه
        [Required]
        public decimal price { get; set; }
        [Required]
        public int count { get; set; }


        //navigation
        [ForeignKey("OrderId")]
        public Order order { get; set; }


        //فارین کی رو گذاشتم چون بفهمه کدوم پراپرتی کلید خارجی برای کلید اصلی جدول محصولات میشه
        [ForeignKey("ProductId")]
        public product product { get; set; }
    }
}
