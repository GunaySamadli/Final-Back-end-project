using Mejuri_Back_end.Models;
using Mejuri_Back_end.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _contextAccessor;

        public ShopController(AppDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public IActionResult Index(int? minPrice, int? maxPrice, string search = null, int? categoryId = null, int? materailId = null, int? genderId = null, int page = 1)
        {
            var query = _context.Products.Include(x=>x.ProductMaterials).ThenInclude(x=>x.Material)
                .AsQueryable();

            if (minPrice != null) query = query.Where(x => x.SalePrice > minPrice);
            if (maxPrice != null) query = query.Where(x => x.SalePrice < maxPrice);

            ViewBag.CurrentCategoryId = categoryId;
            ViewBag.CurrentMaterialId = materailId;
            ViewBag.CurrentSearch = search;
            ViewBag.CurrentGenderId = genderId;

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Name.Contains(search));

            if (categoryId != null)
                query = query.Where(x => x.CategoryId == categoryId);


            if (materailId != null)
                query = query.Where(x => x.ProductMaterials.Any(x=>x.MaterialId == materailId)) ;

            if (genderId != null)
                query = query.Where(x => x.GenderId == genderId);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            #region Favory
            ViewBag.Favorites = null;

            AppUser member = null;

            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == _contextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }

            List<FavoryItemViewModel> items = new List<FavoryItemViewModel>();
            if (member == null)
            {
                var itemsStr = _contextAccessor.HttpContext.Request.Cookies["Favory"];

                if (itemsStr != null)
                {
                    items = JsonConvert.DeserializeObject<List<FavoryItemViewModel>>(itemsStr);

                    foreach (var item in items)
                    {
                        ProductColor product = _context.ProductColors.Include(x => x.Color)
                            .Include(c => c.ProductColorImages).Include(x => x.Product).FirstOrDefault(x => x.Id == item.ProductColorId);

                        if (product != null)
                        {
                            item.Name = product.Product.Name;
                            item.Price = product.Product.SalePrice;
                            item.ColorName = product.Color.Name;
                            item.Image = product.ProductColorImages.FirstOrDefault(x => x.PosterStatus == true)?.Image;
                        }
                    }
                }
            }
            else
            {
                List<FavoryItem> favories = _context.FavoryItems
                    .Include(x => x.ProductColor).ThenInclude(x => x.ProductColorImages)
                    .Include(x => x.ProductColor).ThenInclude(x => x.Product)
                    .Include(x => x.ProductColor).ThenInclude(x => x.Color)
                    .Where(x => x.AppUserId == member.Id).ToList();
                items = favories.Select(x => new FavoryItemViewModel
                {
                    ProductColorId = x.ProductColorId,
                    Image = x.ProductColor.ProductColorImages.FirstOrDefault(bi => bi.PosterStatus == true)?.Image,
                    Name = x.ProductColor.Product.Name,
                    ColorName = x.ProductColor.Color.Name,
                    Price = x.ProductColor.Product.SalePrice
                }).ToList();
            }
            ViewBag.Favorites = items;
            #endregion


            List<Product> products = query
               .Include(x => x.ProductColors).ThenInclude(x => x.Color)
               .Include(x => x.ProductColors).ThenInclude(x => x.ProductColorImages)
               .Skip((page - 1) * 6).Take(6).ToList();

            ShopViewModel shopVM = new ShopViewModel
            {
                Products = products,
                Categories = _context.Categories.ToList(),
                Genders = _context.Genders.ToList(),
                ProductMaterials = _context.ProductMaterials.Include(x => x.Material).ToList()
            };
            ViewBag.TotalPage = Math.Ceiling(query.Count() / 6m);
            ViewBag.SelectedPage = page;
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
            question.Accept = true;
            _context.Answers.Add(newAnswer);
            _context.SaveChanges();


            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }
    }
}
