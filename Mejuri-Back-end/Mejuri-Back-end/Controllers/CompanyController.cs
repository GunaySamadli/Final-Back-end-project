using Mejuri_Back_end.Models;
using Mejuri_Back_end.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        public IActionResult Index(int page = 1, int? categoryId = null)
        {
            var query = _context.Companies
                .AsQueryable();

            ViewBag.CurrentCategoryId = categoryId;

            if (categoryId != null)
                query = query.Where(x => x.CompanyCategoryId == categoryId);

            List<Company> companies = query
                .Include(x => x.Product).ThenInclude(x => x.ProductColors).ThenInclude(x => x.Color)
                .Include(x => x.Product).ThenInclude(x => x.ProductColors).ThenInclude(x => x.ProductColorImages)
                .Skip((page - 1) * 6).Take(6).ToList();


            CompanyViewModel companyVM = new CompanyViewModel
            {
               Companies=companies,
               CompanyCategories = _context.CompanyCategories.ToList(),
            };

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 6m);
            ViewBag.SelectedPage = page;
            return View(companyVM);

        }
    };

}
