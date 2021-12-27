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
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Contacts.AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Title.Contains(search));
            }

            List<Contact> contacts= query
               .Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null) return RedirectToAction("index", "error");

            return View(contact);
        }

        [HttpPost]

        public IActionResult Edit(int? id, Contact contact)
        {
            if (!ModelState.IsValid) return NotFound();

            Contact existContact = _context.Contacts.FirstOrDefault(x => x.Id == contact.Id);

            if (existContact == null) return RedirectToAction("index", "error");

            existContact.Icon = contact.Icon;
            existContact.Title = contact.Title;
            existContact.SubTitle = contact.SubTitle;
            existContact.RedirectUrl = contact.RedirectUrl;
            existContact.RedirectUrlText = contact.RedirectUrlText;



            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null) return Json(new { status = 404 });

            try
            {
                _context.Contacts.Remove(contact);
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
