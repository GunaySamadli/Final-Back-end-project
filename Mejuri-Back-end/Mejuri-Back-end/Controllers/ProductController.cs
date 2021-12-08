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

                Product = _context.Products
                .Include(x=>x.ProductColors).ThenInclude(x=>x.ProductColorImages)
                .Include(x=>x.ProductColors).ThenInclude(x=>x.Color)
                .Include(x => x.ProductMaterials).ThenInclude(x => x.Material).Where(x=>x.Id==id).FirstOrDefault()


            };
           
            return View(shopVM);
        }
    }
}
