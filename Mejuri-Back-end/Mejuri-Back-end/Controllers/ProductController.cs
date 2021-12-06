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
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            ShopViewModel shopVM = new ShopViewModel
            {
                ProductColor= _context.ProductColors
               .Include(x => x.ProductColorImages)
               .Include(x => x.Product).
               Include(x => x.Color).FirstOrDefault(x => x.Id == id),

                Product = _context.Products
                .Include(x=>x.ProductColors).ThenInclude(x=>x.ProductColorImages)
                .Include(x=>x.ProductColors).ThenInclude(x=>x.Color)
                .Include(x => x.ProductMaterials).ThenInclude(x => x.Material).FirstOrDefault(x => x.Id == id)

            };
           
            return View(shopVM);
        }
    }
}
