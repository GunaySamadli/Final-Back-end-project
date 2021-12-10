using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    [Area("manage")]
    public class MaterialController : Controller
    {
        private readonly AppDbContext _context;

        public MaterialController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Material> materials = _context.Materials.ToList();
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

            _context.Materials.Add(material);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Material material = _context.Materials.FirstOrDefault(x => x.Id == id);

            if (material == null) return NotFound();

            return View(material);
        }


        [HttpPost]

        public IActionResult Edit(Material material)
        {
            if (!ModelState.IsValid) return NotFound();

            Material existMaterial = _context.Materials.FirstOrDefault(x => x.Id == material.Id);

            if (existMaterial == null) return NotFound();


            existMaterial.Name = material.Name;

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
