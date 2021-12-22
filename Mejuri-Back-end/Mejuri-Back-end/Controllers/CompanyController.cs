using Mejuri_Back_end.Models;
using Mejuri_Back_end.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            List<Company> companies = _context.Companies.
                Include(x => x.Product).ThenInclude(x => x.ProductColors).ThenInclude(x => x.Color)
                .Include(x => x.Product).ThenInclude(x => x.ProductColors).ThenInclude(x => x.ProductColorImages)
                .ToList();
           
            CompanyViewModel companyVM = new CompanyViewModel
            {
               Companies=companies,
               CompanyCategories = _context.CompanyCategories.ToList(),
            };
            return View(companyVM);

        }
    };

}
