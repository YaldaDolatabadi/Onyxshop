using System.ComponentModel.DataAnnotations;

namespace Onyxshop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime Createdate { get; set; }
        [Required]
        public bool isfinally { get; set; }

        //navigation
        public User User { get; set; }
        public List<OrderDetails> details { get; set; }

    }
}
