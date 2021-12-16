using Mejuri_Back_end.Models;
using Mejuri_Back_end.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Brands = _context.Brands.ToList(),
                Sliders = _context.Sliders.ToList(),
                Categories = _context.Categories.ToList(),
                CompanyCategories = _context.CompanyCategories.ToList(),
                Products = _context.Products
                .Include(x => x.ProductColors).ThenInclude(x=>x.ProductColorImages)
                .Include(x => x.Company)
                .ToList(),
                Companies = _context.Companies.ToList()
            };

            return View(homeVM);
        }

    }
}
