using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class MaterialController : Controller
    {
        private readonly AppDbContext _context;

        public MaterialController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1, string search = null)
        {
            var query = _context.Materials.AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            List<Material> materials = query
               .Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;

            return View(materials);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Material material)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (_context.Materials.Any(x => x.Name.ToLower() == material.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "The name is already available");
                return View();
            }

            _context.Materials.Add(material);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Material material = _context.Materials.FirstOrDefault(x => x.Id == id);

            if (material == null) return RedirectToAction("index", "error");

            return View(material);
        }


        [HttpPost]

        public IActionResult Edit(Material material)
        {
            if (!ModelState.IsValid) return NotFound();

            Material existMaterial = _context.Materials.FirstOrDefault(x => x.Id == material.Id);

            if (existMaterial == null) return RedirectToAction("index", "error");


            existMaterial.Name = material.Name;

            if (_context.Materials.Any(x => x.Name.ToLower() == material.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "The name is already available");
                return View();
            }

            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            Material material = _context.Materials.FirstOrDefault(x => x.Id == id);
            if (material == null) return Json(new { status = 404 });

            try
            {
                _context.Materials.Remove(material);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }

            return Json(new { status = 200 });
        }
    }
}
