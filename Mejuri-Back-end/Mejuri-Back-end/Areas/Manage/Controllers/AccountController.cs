using Mejuri_Back_end.Areas.Manage.ViewModels;
using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {

            return Ok(new
            {
                UserName = User.Identity.Name,
                IsLogged = User.Identity.IsAuthenticated
            });

            //AppUser admin = new AppUser
            //{
            //    UserName = "SuperAdmin",
            //    FullName = "Super Admin"
            //};

            //var result=await _userManager.CreateAsync(admin, "Admin123");

            //IdentityRole role1 = new IdentityRole("SuperAdmin");
            //await _roleManager.CreateAsync(role1);
            //IdentityRole role2 = new IdentityRole("Admin");
            //await _roleManager.CreateAsync(role2);
            //IdentityRole role3 = new IdentityRole("Member");
            //await _roleManager.CreateAsync(role3);

            //AppUser admin = await _userManager.FindByNameAsync("SuperAdmin");
            //await _userManager.AddToRoleAsync(admin, "SuperAdmin");


            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser admin = _userManager.Users.FirstOrDefault(x => x.NormalizedUserName == loginVM.UserName.ToUpper() && x.IsAdmin==true);

            if (admin == null)
            {
                ModelState.AddModelError("", "Istifadeci adi ve ya sifre yanlisdir!");
                return View();
            }
            var result =await _signInManager.PasswordSignInAsync(admin, loginVM.Password, loginVM.IsPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Istifadeci adi ve ya sifre yanlisdir!");
                return View();
            }
            return RedirectToAction("index","dashboard");
        }


        [Authorize(Roles = "SuperAdmin")]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> AddAdmin(AddAdminViewModel addAdmin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser admin = await _userManager.FindByNameAsync(addAdmin.UserName);
            if (admin != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            admin = await _userManager.FindByEmailAsync(addAdmin.Email);
            if (admin != null)
            {
                ModelState.AddModelError("Email", "Email already taken!");
                return View();
            }


            admin = new AppUser
            {
                FullName = addAdmin.FullName,
                UserName = addAdmin.UserName,
                Email = addAdmin.Email,
                IsAdmin = true
            };

            var result = await _userManager.CreateAsync(admin, addAdmin.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            var roleResult = await _userManager.AddToRoleAsync(admin, "Admin");
            await _signInManager.SignInAsync(admin, true);

            return RedirectToAction("index", "dashboard");
        }


    }
}
