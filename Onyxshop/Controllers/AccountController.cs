using Microsoft.AspNetCore.Mvc;
using Onyxshop.Models;
using Onyxshop.Data.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Onyxshop.Controllers
{
    public class AccountController : Controller
    {
        IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }
        #region register
        //وقتی وارد قسمت ثبت نام شد
        public IActionResult GotoRegister()
        {
            return View();
        }

        //وقتی فرم رو پر کرد و رو ثبت نام زد
        [HttpPost]
        public IActionResult GotoRegister(RegisterViewModel registerViewmodel)
        {
            
            if (!ModelState.IsValid)
            {
                return View(registerViewmodel);
            }
            else if (_userRepository.isexistuserbyphone(registerViewmodel.PhoneNo))
            //خطا
            {
                ModelState.AddModelError("PhoneNo", "کاربر با این شماره تلفن قبلا ثبت نام کرده است");
                return View(registerViewmodel);
            }
            else
            {
                var user = new User
                {
                    UserName = registerViewmodel.UserName,
                    PhoneNo = registerViewmodel.PhoneNo,
                    Password = registerViewmodel.Password,
                    RegisterDate=DateTime.Now,
                    IsAdmin = false
                };
            _userRepository.Adduser(user);

                return View("RegisterSuccess");
            }
        }
        #endregion
        

        #region login

        //وقتی وارد قسمت ورود شد
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(loginviewmodel loginviewmodel)
        {
            //عملیات ورود
            if (!ModelState.IsValid)
            {
                return View(loginviewmodel);
            }

            var v = _userRepository.getuserforlogin(loginviewmodel.usernameorphoneno, loginviewmodel.password);

            if (v == null)
            {
                ModelState.AddModelError("usernameorphoneno", "کاربری یا رمز عبور نادرست است");
                ModelState.AddModelError("Password", "کاربری یا رمز عبور نادرست است");
                return View(loginviewmodel);
            }


            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,v.UserId.ToString()),
               // new Claim(ClaimTypes.Name,v.PhoneNo),
                new Claim(ClaimTypes.Name,v.UserName),
        
               // new Claim("CodeMeli", user.Email),

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = loginviewmodel.rememberme
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }
        #endregion

        #region logout
        public IActionResult logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login");
        }

        #endregion

    }
}
