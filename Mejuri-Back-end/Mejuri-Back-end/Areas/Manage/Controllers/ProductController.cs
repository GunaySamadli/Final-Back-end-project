using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            
            var query = _context.Products.AsQueryable();

            List<Product> products = query
                .Include(x=>x.Category).Include(x=>x.Gender)
                .Include(x => x.ProductColors).ThenInclude(x => x.ProductColorImages)
                .Include(x => x.ProductColors).ThenInclude(x => x.Color)
                .Include(x => x.ProductMaterials).ThenInclude(x => x.Material)
                .Include(x=>x.Company).ThenInclude(x=>x.CompanyCategory)
                .ToList();

            var pagenatedSlider = PagenatedList<Product>.Create(query, 4, page);

            return View(pagenatedSlider);

        }

        public IActionResult Create()
        {
            ViewBag.ProductColorImage = _context.ProductColorImages.ToList();
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.Gender = _context.Genders.ToList();
            ViewBag.Company = _context.Companies.ToList();
            ViewBag.Color = _context.Colors.ToList();
            ViewBag.Material = _context.Materials.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ViewBag.ProductColorImage = _context.ProductColorImages.ToList();
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.Gender = _context.Genders.ToList();
            ViewBag.Company = _context.Companies.ToList();
            ViewBag.Color = _context.Colors.ToList();
            ViewBag.Material = _context.Materials.ToList();

            if (!_context.Genders.Any(x => x.Id == product.GenderId)) ModelState.AddModelError("GenderId", "Gender not found!");
            if (!_context.Categories.Any(x => x.Id == product.CategoryId)) ModelState.AddModelError("CategoryId", "Category not found!");
            if (!_context.Companies.Any(x => x.Id == product.CompanyId)) ModelState.AddModelError("CompanyId", "Company not found!");

            foreach (var materialid in product.MaterialIds)
            {
                Material material = _context.Materials.FirstOrDefault(x => x.Id == materialid);

                if (material == null)
                {
                    ModelState.AddModelError("MaterialId", "Material not found!");
                    return View();
                }

                ProductMaterial productMaterial = new ProductMaterial
                {
                    MaterialId = materialid
                };
                product.ProductMaterials.Add(productMaterial);
            }

            foreach (var colorid in product.ColorIds)
            {
                Color color = _context.Colors.FirstOrDefault(x => x.Id == colorid);

                if (color == null)
                {
                    ModelState.AddModelError("ColorId", "Color not found!");
                    return View();
                }

                ProductColor productColor = new ProductColor
                {
                    ColorId = colorid
                };
                product.ProductColors.Add(productColor);
            }
           

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Product product = _context.Products
                .Include(x => x.Category).Include(x => x.Gender)
                .Include(x => x.ProductColors).ThenInclude(x => x.ProductColorImages)
                .Include(x => x.ProductColors).ThenInclude(x => x.Color)
                .Include(x => x.ProductMaterials).ThenInclude(x => x.Material)
                .Include(x => x.Company).ThenInclude(x => x.CompanyCategory)
                .FirstOrDefault(x => x.Id == id);

            ViewBag.Category = _context.Categories.ToList();
            ViewBag.Gender = _context.Genders.ToList();
            ViewBag.Company = _context.Companies.ToList();
            ViewBag.Color = _context.Colors.ToList();
            ViewBag.Material = _context.Materials.ToList();
            ViewBag.ProductColorImage = _context.ProductColorImages.ToList();

            product.MaterialIds = product.ProductMaterials.Select(x => x.MaterialId).ToList();
            product.ColorIds = product.ProductColors.Select(x => x.ColorId).ToList();

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!_context.Genders.Any(x => x.Id == product.GenderId)) ModelState.AddModelError("GenderId", "Gender not found!");
            if (!_context.Categories.Any(x => x.Id == product.CategoryId)) ModelState.AddModelError("CategoryId", "Category not found!");

            if (!ModelState.IsValid) return View();

            if (!_context.Companies.Any(x => x.Id == product.CompanyId)) ModelState.AddModelError("CompanyId", "Company not found!");

            Product existProudct = _context.Products.Include(x => x.ProductMaterials).Include(x => x.ProductColors).FirstOrDefault(x => x.Id == product.Id);

            if (existProudct == null) return NotFound();

            existProudct.ProductMaterials.RemoveAll(x => !product.MaterialIds.Contains(x.MaterialId));


            if (product.MaterialIds != null)
            {
                foreach (var materialId in product.MaterialIds.Where(x => !existProudct.ProductMaterials.Any(bt => bt.MaterialId == x)))
                {
                    ProductMaterial productMaterial = new ProductMaterial
                    {
                        MaterialId = materialId,
                        ProductId = product.Id
                    };

                    existProudct.ProductMaterials.Add(productMaterial);
                }
            }

            existProudct.ProductColors.RemoveAll(x => !product.ColorIds.Contains(x.ColorId));


            if (product.ColorIds != null)
            {
                foreach (var colorId in product.ColorIds.Where(x => !existProudct.ProductColors.Any(bt => bt.ColorId == x)))
                {
                    ProductColor productColor = new ProductColor
                    {
                        ColorId = colorId,
                        ProductId = product.Id
                    };

                    existProudct.ProductColors.Add(productColor);
                }
            }




            existProudct.Name = product.Name;
            existProudct.CategoryId = product.CategoryId;
            existProudct.GenderId = product.GenderId;
            existProudct.CompanyId = product.CompanyId;
            existProudct.SalePrice = product.SalePrice;
            existProudct.Desc = product.Desc;
            existProudct.Rate = product.Rate;
            existProudct.IsStock = product.IsStock;
            existProudct.ShippingPrice = product.ShippingPrice;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null) return Json(new { status = 404 });

            try
            {
                _context.Products.Remove(product);
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
