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
    public class FaqController : Controller
    {
        private readonly AppDbContext _context;

        public FaqController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Faqs.AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Question.Contains(search));
            }

            List<Faq> faqs = query
               .Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;

            return View(faqs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Faq faq)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Faqs.Add(faq);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Faq faq = _context.Faqs.FirstOrDefault(x => x.Id == id);

            if (faq == null) return RedirectToAction("index", "error");

            return View(faq);
        }

        [HttpPost]

        public IActionResult Edit(int? id, Faq faq)
        {
            if (!ModelState.IsValid) return NotFound();

            Faq  existFaq = _context.Faqs.FirstOrDefault(x => x.Id == faq.Id);

            if (existFaq == null) return RedirectToAction("index", "error");

            existFaq.Order = faq.Order;
            existFaq.Question = faq.Question;
            existFaq.Answer = faq.Answer;


            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            Faq faq = _context.Faqs.FirstOrDefault(x => x.Id == id);
            if (faq == null) return Json(new { status = 404 });

            try
            {
                _context.Faqs.Remove(faq);
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
