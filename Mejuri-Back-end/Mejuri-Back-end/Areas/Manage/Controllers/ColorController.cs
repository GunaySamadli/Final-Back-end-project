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
    public class ColorController : Controller
    {
        public readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ColorController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Colors.AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            List<Color> colors = query
               .Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;


            return View(colors);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Color color)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (color.ImageFile != null)
            {
                if (color.ImageFile.ContentType != "image/png" && color.ImageFile.ContentType != "image/jpeg" && color.ImageFile.ContentType != "image/jfif" && color.ImageFile.ContentType != "image/svg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg,jfif or png!");
                    return View();
                }
                if (color.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }
                string fileName = color.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/color", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    color.ImageFile.CopyTo(stream);
                }
                color.Image = newFileName;
            }

            _context.Colors.Add(color);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Color color = _context.Colors.FirstOrDefault(x => x.Id == id);
            if (color == null) return NotFound();

            return View(color);
        }
        [HttpPost]
        public IActionResult Edit(Color color)
        {
            if (!ModelState.IsValid) return NotFound();

            Color existColor = _context.Colors.FirstOrDefault(x => x.Id == color.Id);

            if (existColor == null) return NotFound();

            if (color.ImageFile != null)
            {
                if (color.ImageFile.ContentType != "image/png" && color.ImageFile.ContentType != "image/jpeg" && color.ImageFile.ContentType != "image/jfif" && color.ImageFile.ContentType != "image/svg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg,jfif or png!");
                    return View();
                }
                if (color.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                string fileName = color.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/color", newFileName);

                if (existColor.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/color", existColor.Image);
                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    color.ImageFile.CopyTo(stream);
                }
                existColor.Image = newFileName;
            }
            else if (color.Image == null && existColor.Image != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "uploads/color", existColor.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                existColor.Image = null;
            }

            existColor.Name = color.Name;
            existColor.Desc = color.Desc;


            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            Color color= _context.Colors.FirstOrDefault(x => x.Id == id);
            if (color == null) return Json(new { status = 404 });

            try
            {
                _context.Colors.Remove(color);
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
