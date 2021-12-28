using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Controllers
{
    public class FaqController : Controller
    {
        private readonly AppDbContext _context;

        public FaqController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Faq> faqs = _context.Faqs.OrderBy(x=>x.Order).ToList();
            return View(faqs);
        }
    }
}
