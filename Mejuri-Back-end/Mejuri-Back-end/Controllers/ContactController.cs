using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Contact> contacts = _context.Contacts.ToList();

            return View(contacts);
        }
    }
}
