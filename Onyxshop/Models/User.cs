using System.ComponentModel.DataAnnotations;

namespace Onyxshop.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(15)]
        //[RegularExpression(@"^([0-9]{10})$")]
        public string PhoneNo { get; set; }
        [Required]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }

        //navigation
        public List<Order> Orders { get; set; }
    }
}
