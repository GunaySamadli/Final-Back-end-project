using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    [Area("manage")]
    public class GenderController : Controller
    {
        private readonly AppDbContext _context;

        public GenderController(AppDbContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            List<Gender> genders = _context.Genders.ToList();
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

            _context.Genders.Add(gender);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Gender gender = _context.Genders.FirstOrDefault(x => x.Id == id);

            if (gender == null) return NotFound();

            return View(gender);
        }


        [HttpPost]

        public IActionResult Edit(Gender gender)
        {
            if (!ModelState.IsValid) return NotFound();

            Gender existGender  = _context.Genders.FirstOrDefault(x => x.Id == gender.Id);

            if (existGender == null) return NotFound();


            existGender.Name = gender.Name;

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
