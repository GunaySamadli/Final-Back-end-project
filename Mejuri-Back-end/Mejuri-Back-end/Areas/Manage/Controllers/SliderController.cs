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
    public class SliderController : Controller
    {
        public readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Sliders.AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Title.Contains(search));
            }

            List<Slider> sliders = query
               .Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;


            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (slider.ImageFile != null)
            {
                if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/jfif")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg,jfif or png!");
                    return View();
                }
                if (slider.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }
                string fileName = slider.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/slider", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.ImageFile.CopyTo(stream);
                }
                slider.Image = newFileName;
            }

            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider == null) return RedirectToAction("index", "error");

            return View(slider);
        }
        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            if (!ModelState.IsValid) return NotFound();

            Slider existSlider = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);

            if (existSlider == null) return RedirectToAction("index", "error");

            if (slider.ImageFile != null)
            {
                if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/jfif")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg,jfif or png!");
                    return View();
                }
                if (slider.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                string fileName = slider.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/slider", newFileName);

                if (existSlider.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/slider", existSlider.Image);
                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.ImageFile.CopyTo(stream);
                }
                existSlider.Image = newFileName;
            }
            else if (slider.Image == null && existSlider.Image != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "uploads/slider", existSlider.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                existSlider.Image = null;
            }

            existSlider.Title = slider.Title;
            existSlider.SubTitle = slider.SubTitle;


            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider == null) return Json(new { status = 404 });

            try
            {
                _context.Sliders.Remove(slider);
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
