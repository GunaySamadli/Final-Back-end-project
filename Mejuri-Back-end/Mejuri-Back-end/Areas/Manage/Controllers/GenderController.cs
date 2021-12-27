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
    public class GenderController : Controller
    {
        private readonly AppDbContext _context;

        public GenderController(AppDbContext context)
        {
           _context = context;
        }
        public IActionResult Index(int page=1, string search = null)
        {
            var query = _context.Genders.AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            List<Gender> genders = query
               .Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;

            return View(genders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Gender gender)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_context.Genders.Any(x => x.Name.ToLower() == gender.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "The name is already available");
                return View();
            }

            _context.Genders.Add(gender);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Gender gender = _context.Genders.FirstOrDefault(x => x.Id == id);

            if (gender == null) return RedirectToAction("index", "error");

            return View(gender);
        }


        [HttpPost]

        public IActionResult Edit(Gender gender)
        {
            if (!ModelState.IsValid) return NotFound();

            Gender existGender  = _context.Genders.FirstOrDefault(x => x.Id == gender.Id);

            if (existGender == null) return RedirectToAction("index", "error");


            existGender.Name = gender.Name;

            if (_context.Genders.Any(x => x.Name.ToLower() == gender.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "The name is already available");
                return View();
            }

            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            Gender gender = _context.Genders.FirstOrDefault(x => x.Id == id);
            if (gender == null) return Json(new { status = 404 });

            try
            {
                _context.Genders.Remove(gender);
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
