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
    public class CompanyController : Controller
    {
        private readonly AppDbContext _context;

        public CompanyController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            CompanyViewModel companyVM = new CompanyViewModel
            {
               
                CompanyCategories = _context.CompanyCategories.ToList(),
               
                //Companies=_context.Companies.
                //Include(x=>x.Products).ThenInclude(x=>x.ProductColors)
                //.ThenInclude(x=>x.ProductColorImages)
                //.Include(x => x.Products).ThenInclude(x => x.ProductColors)
                //.ThenInclude(x => x.Color)
                //.Include(x=>x.CompanyCategory)
                //.ToList(),

                //Products = _context.Products
                //.Include(x=>x.Company).ThenInclude(x=>x.CompanyCategory)
                //.Include(x => x.ProductColors).ThenInclude(x => x.ProductColorImages)
                //.Include(x => x.ProductColors).ThenInclude(x => x.Color)
                //.ToList(),

                // ProductColors = _context.ProductColors
                //.Include(x => x.Product).ThenInclude(x => x.Company).ThenInclude(x=>x.CompanyCategory)
                //.Include(x => x.ProductColorImages).Include(x=>x.Color)
                //.ToList()
            };
            return View(companyVM);

        }


    };

}
