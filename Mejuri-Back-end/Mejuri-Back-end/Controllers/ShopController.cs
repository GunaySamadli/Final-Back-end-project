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
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products
               .Include(x => x.ProductColors).ThenInclude(x => x.Color)
               .Include(x => x.ProductColors).ThenInclude(x => x.ProductColorImages).ToList();

            ShopViewModel shopVM = new ShopViewModel
            {
                Products=products,
                Categories=_context.Categories.ToList(),
                Genders = _context.Genders.ToList(),
                ProductMaterials=_context.ProductMaterials.Include(x=>x.Material).ToList()

            };
            return View(shopVM);
        }
    }
}
