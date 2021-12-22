using Mejuri_Back_end.Models;
using Mejuri_Back_end.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ShopController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            string strPr = HttpContext.Request.Cookies["Favory"];
            ViewBag.Favorites = null;
            if (strPr != null)
            {
                ViewBag.Favorites = JsonConvert.DeserializeObject<List<FavoryItemViewModel>>(strPr);

            }


            List<Product> products = _context.Products
               .Include(x => x.ProductColors).ThenInclude(x => x.Color)
               .Include(x => x.ProductColors).ThenInclude(x => x.ProductColorImages).ToList();

            ShopViewModel shopVM = new ShopViewModel
            {
                Products=products,
                Categories=_context.Categories.ToList(),
                Genders = _context.Genders.ToList(),
                ProductMaterials=_context.ProductMaterials.Include(x=>x.Material).ToList()

            };
            return View(shopVM);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(int id, Review review)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            Review newReview = new Review
            {
                Email = review.Email,
                Username = review.Username,
                Rate = review.Rate,
                Date = DateTime.UtcNow,
                Text = review.Text,
                ProductId = id,
                Accept = false,
                AppUserId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id

            };
            _context.Reviews.Add(newReview);
            _context.SaveChanges();


            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }



        [Authorize(Roles = "Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Question(int id, Question question)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            Question newQuestion = new Question
            {
                Email = question.Email,
                Username = question.Username,
                Date = DateTime.UtcNow,
                Text = question.Text,
                ProductId = id,
                Accept = false,
                AppUserId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id

            };
            _context.Questions.Add(newQuestion);
            _context.SaveChanges();


            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Answer(int id, Answer answer)
        {
            var question = _context.Questions.FirstOrDefault(x => x.Id == id);

            Answer newAnswer = new Answer
            {
                Date = DateTime.UtcNow,
                Text = question.Text,
                QuestionId = id,

            };
            _context.Answers.Add(newAnswer);
            _context.SaveChanges();


            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }
    }
}
