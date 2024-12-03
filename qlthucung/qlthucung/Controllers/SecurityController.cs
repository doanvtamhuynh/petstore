using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qlthucung.Models;
using qlthucung.Security;
using Microsoft.AspNetCore.Http;

namespace qlthucung.Controllers
{
    public class SecurityController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;

        public SecurityController(UserManager<AppIdentityUser> userManager,
            RoleManager<AppIdentityRole> roleManager,
            SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                if (!roleManager.RoleExistsAsync("User").Result) //staff và chỉnh role bên này
                {
                    var role = new AppIdentityRole();
                    role.Name = "User"; //staff
                    role.Description = "User can Perform CRUD Employee";
                    var roleResult = roleManager.CreateAsync(role).Result;
                }

                var user = new AppIdentityUser();
                user.UserName = register.UserName;
                user.Email = register.Email;
                user.FullName = register.FullName;
                user.BirthDate = register.BirthDate;

                var result = userManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait(); //"User" thay bằng staff
                    return RedirectToAction("SignIn", "Security");
                }
                else
                {
                    ModelState.AddModelError("", "Loi Dang Ky");
                }
            }
            return View(register);
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(signIn.UserName, signIn.Password, signIn.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("username", signIn.UserName);
                    return RedirectToAction("Index", "SanPham");
                }

                else
                    TempData["LoginErr"] = "Tên tài khoản hoặc mật khẩu không chính xác!";
            }
            return View(signIn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult SignOut()
        {
            signInManager.SignOutAsync().Wait();
            HttpContext.Session.Remove("username");
            return RedirectToAction("SignIn", "Security");

        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
