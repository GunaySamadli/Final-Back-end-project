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

        
    }
}
