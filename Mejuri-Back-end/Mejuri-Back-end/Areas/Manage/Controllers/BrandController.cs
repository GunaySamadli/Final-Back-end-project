using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class BrandController : Controller
    {
        public readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BrandController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Brands.AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Text.Contains(search));
            }

            List<Brand> brands = query
               .Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;


            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (brand.ImageFile != null)
            {
                if (brand.ImageFile.ContentType != "image/png" && brand.ImageFile.ContentType != "image/jpeg" && brand.ImageFile.ContentType != "image/jfif")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg,jfif or png!");
                    return View();
                }
                if (brand.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }
                string fileName = brand.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/brand", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    brand.ImageFile.CopyTo(stream);
                }
                brand.Image = newFileName;
            }

            _context.Brands.Add(brand);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(x => x.Id == id);
            if (brand == null) return RedirectToAction("index", "error");

            return View(brand);
        }
        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            if (!ModelState.IsValid) return NotFound();

            Brand existBrand = _context.Brands.FirstOrDefault(x => x.Id == brand.Id);

            if (existBrand == null) return RedirectToAction("index", "error");

            if (brand.ImageFile != null)
            {
                if (brand.ImageFile.ContentType != "image/png" && brand.ImageFile.ContentType != "image/jpeg" && brand.ImageFile.ContentType != "image/jfif")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg,jfif or png!");
                    return View(existBrand);
                }
                if (brand.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View(existBrand);
                }

                string fileName = brand.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/brand", newFileName);

                if (existBrand.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/brand", existBrand.Image);
                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    brand.ImageFile.CopyTo(stream);
                }
                existBrand.Image = newFileName;
            }
            else if (brand.Image == null && existBrand.Image != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "uploads/brand", existBrand.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                existBrand.Image = null;
            }

            existBrand.Text = brand.Text;


            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(x => x.Id == id);
            if (brand == null) return Json(new { status = 404 });

            try
            {
                _context.Brands.Remove(brand);
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
