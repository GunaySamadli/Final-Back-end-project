using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CompanyCategoryController : Controller
    {
        public readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CompanyCategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<CompanyCategory> companyCategories = _context.CompanyCategories.ToList();

            return View(companyCategories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CompanyCategory companyCategory)
        {
            if (!ModelState.IsValid) return View();

            if (companyCategory.ImageFile != null)
            {
                if (companyCategory.ImageFile.ContentType != "image/png" && companyCategory.ImageFile.ContentType != "image/jpeg" && companyCategory.ImageFile.ContentType != "image/jfif")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg,jfif or png!");
                    return View();
                }
                if (companyCategory.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }
                string fileName = companyCategory.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/companycategory", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    companyCategory.ImageFile.CopyTo(stream);
                }
                companyCategory.Image = newFileName;
            }

            _context.CompanyCategories.Add(companyCategory);
            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult Edit(int id)
        {
            CompanyCategory companyCategory = _context.CompanyCategories.FirstOrDefault(x => x.Id == id);

            if (companyCategory == null) return NotFound();

            return View(companyCategory);
        }

        [HttpPost]
        public IActionResult Edit(CompanyCategory companyCategory)
        {
            if (!ModelState.IsValid) return NotFound();

            CompanyCategory existCategory = _context.CompanyCategories.FirstOrDefault(x => x.Id == companyCategory.Id);

            if (existCategory == null) return NotFound();

            if (companyCategory.ImageFile != null)
            {
                if (companyCategory.ImageFile.ContentType != "image/png" && companyCategory.ImageFile.ContentType != "image/jpeg" && companyCategory.ImageFile.ContentType != "image/jfif")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg,jfif or png!");
                    return View();
                }
                if (companyCategory.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                string fileName = companyCategory.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/companycategory", newFileName);

                if (existCategory.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/companycategory", existCategory.Image);
                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    companyCategory.ImageFile.CopyTo(stream);
                }
                existCategory.Image = newFileName;
            }
            else if (companyCategory.Image == null && existCategory.Image != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "uploads/companycategory", existCategory.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                existCategory.Image = null;
            }

            existCategory.Name = companyCategory.Name;

            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            CompanyCategory companyCategory = _context.CompanyCategories.FirstOrDefault(x => x.Id == id);
            if (companyCategory == null) return Json(new { status = 404 });

            try
            {
                _context.CompanyCategories.Remove(companyCategory);
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
