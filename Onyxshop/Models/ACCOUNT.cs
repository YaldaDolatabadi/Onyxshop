using System.ComponentModel.DataAnnotations;
//کلیه کلاس های مربوط به احراز هویت
//ویو مدل های ثبت نام و لاگین

namespace Onyxshop.Models
{
   

    //فرم ثبت نام ما باید از روی این مدل ساخته بشود
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است")]
        [MaxLength(100)]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است")]
        [MaxLength(15)]
        [Display(Name = "تلفن همراه")]
        //[RegularExpression(@"^([0-9]{10})$", ErrorMessage = "شماره تلفن همراه معتبر نیست")]
        [RegularExpression("([0-9]+)", ErrorMessage = "شماره تلفن همراه معتبر نیست")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        [Required(ErrorMessage = "تکمیل فیلد {0} الزامی است")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "تکرار رمز عبور مطابقت ندارد")]
        public string RePassword { get; set; }

    }

    public class loginviewmodel
        {
        [Required(ErrorMessage = "لطفا نام کاربری یا شماره تلفن همراه را وارد کنید")]
        [Display(Name ="نام کاربری یا شماره تلفن همراه")]
        public string usernameorphoneno { get; set; }
        [Required(ErrorMessage = "لطفا نام رمز عبور را وارد کنید")]
        [Display(Name = "رمز عبور")]
        public string password { get; set; }

        //با زدن این گزینه برای کاربر یک کوکی ست میشود که یوزر و پسورد نگهداری شود
        [Display(Name = "   مرا به خاطر بسپار")]
        public bool rememberme { get; set; }

    }

}
