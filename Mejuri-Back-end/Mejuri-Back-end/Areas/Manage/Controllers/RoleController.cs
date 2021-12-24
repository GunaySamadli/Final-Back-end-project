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
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(IdentityRole identityRole)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _roleManager.CreateAsync(identityRole);

            await _roleManager.UpdateAsync(identityRole);

            return RedirectToAction("index");
        }


        public IActionResult Edit(string name)
        {
            IdentityRole role = _roleManager.Roles.FirstOrDefault(x => x.Name == name);
            if (role == null) return NotFound();

            TempData["name"] = name;

            return View(role);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(IdentityRole identityRole)
        {
            var name = TempData["name"];
            IdentityRole existRole = _roleManager.Roles.FirstOrDefault(x => x.Name == name.ToString());

            if (existRole == null) return NotFound();

            existRole.Name = identityRole.Name;

            await _roleManager.UpdateAsync(existRole);

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(string name)
        {
            IdentityRole deleterole = _roleManager.Roles.FirstOrDefault(x => x.Name == name);

            await _roleManager.DeleteAsync(deleterole);

            return RedirectToAction("index");
        }

    }
}
