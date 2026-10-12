using System.ComponentModel.DataAnnotations;
namespace Onyxshop.Models
 
{
    public class AddorEditProductViewmodel
    {
        //برای ادیت بکار میاد
       
        public int Id { get; set; }
        //[System.ComponentModel.DataAnnotations.Display(Name = "نام محصول")]
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "مقدار الزامی می باشد")]
        public string name { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage ="مقدار الزامی می باشد")]
        public string description { get; set; }
        [Display(Name = "وزن")]
        [Required(ErrorMessage = "مقدار الزامی می باشد")]

        public decimal vazn { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "مقدار الزامی می باشد")]

        public decimal price { get; set; }
        [Display(Name = "تعداد در واحد")]
        [Required(ErrorMessage = "مقدار الزامی می باشد")]

        public int quantityinstock { get; set; }
        [Display(Name = "تصویر")]
        public IFormFile? picture { get; set; }

    }
}
