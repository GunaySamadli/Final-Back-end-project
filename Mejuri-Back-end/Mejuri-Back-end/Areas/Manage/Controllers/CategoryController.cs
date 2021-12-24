using Mejuri_Back_end.Helpers;
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
    public class CategoryController : Controller
    {
        public readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1, string search = null)
        {
            var query = _context.Categories.AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            List<Category> categories = query
               .Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (category.ImageFile != null)
            {
                if (category.ImageFile.ContentType != "image/png" && category.ImageFile.ContentType != "image/jpeg" && category.ImageFile.ContentType != "image/jfif")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg,jfif or png!");
                    return View();
                }
                if (category.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }
                string fileName = category.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/category", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    category.ImageFile.CopyTo(stream);
                }
                category.Image = newFileName;
            }

            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]

        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid) return NotFound();

            Category existCategory = _context.Categories.FirstOrDefault(x => x.Id == category.Id);

            if (existCategory == null) return NotFound();

            if (category.ImageFile != null)
            {
                if (category.ImageFile.ContentType != "image/png" && category.ImageFile.ContentType != "image/jpeg" && category.ImageFile.ContentType != "image/jfif")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg,jfif or png!");
                    return View();
                }
                if (category.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                string fileName = category.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/category", newFileName);

                if (existCategory.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/category", existCategory.Image);
                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    category.ImageFile.CopyTo(stream);
                }
                existCategory.Image = newFileName;
            }
            else if (category.Image == null && existCategory.Image != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "uploads/category", existCategory.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                existCategory.Image = null;
            }

            existCategory.Name = category.Name;

            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null) return Json(new { status = 404 });

            try
            {
                _context.Categories.Remove(category);
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
