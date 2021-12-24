using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class CompanyController : Controller
    {
        private readonly AppDbContext _context;

        public CompanyController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1, string search = null)
        {
            var query = _context.Companies.AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Product.Name.Contains(search));
            }

            List<Company> companies = query
                .Include(x => x.Product).Include(x => x.CompanyCategory)
               .Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;


            return View(companies);
        }

        public IActionResult Create()
        {
            ViewBag.CompanyCategory = _context.CompanyCategories.ToList();
            ViewBag.Product = _context.Products.ToList();


            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            ViewBag.CompanyCategory = _context.CompanyCategories.ToList();
            ViewBag.Product = _context.Products.ToList();


            if (!ModelState.IsValid) return View();

            if (!_context.CompanyCategories.Any(x => x.Id == company.CompanyCategoryId)) ModelState.AddModelError("CompanyCategoryId", "Company Category not found!");
            if (!_context.Products.Any(x => x.Id == company.ProductId)) ModelState.AddModelError("ProductId", "Product not found!");


            _context.Companies.Add(company);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Company company = _context.Companies.Include(x=>x.Product).Include(x=>x.CompanyCategory).FirstOrDefault(x => x.Id == id);

            ViewBag.CompanyCategory = _context.CompanyCategories.ToList();
            ViewBag.Product = _context.Products.ToList();


            if (company == null) return NotFound();

            return View(company);
           
        }

        [HttpPost]
        public IActionResult Edit(Company company)
        {
            if (!_context.CompanyCategories.Any(x => x.Id == company.CompanyCategoryId)) ModelState.AddModelError("CompanyCategoryId", "Company Category not found!");
            if (!_context.Products.Any(x => x.Id == company.ProductId)) ModelState.AddModelError("ProductId", "Product not found!");


            if (!ModelState.IsValid) return View();

            Company existCompany = _context.Companies.FirstOrDefault(x => x.Id == company.Id);


            if (existCompany == null) return NotFound();

            existCompany.CompanyCategoryId = company.CompanyCategoryId;
            existCompany.ProductId = company.ProductId;
            existCompany.Title = company.Title;
            existCompany.Percent = company.Percent;
            existCompany.StartTime = company.StartTime;
            existCompany.EndTime = company.EndTime;


            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            Company company = _context.Companies.FirstOrDefault(x => x.Id == id);

            if (company == null) return Json(new { status = 404 });

            try
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }

            return Json(new { status = 200 });
        }
    }
}
