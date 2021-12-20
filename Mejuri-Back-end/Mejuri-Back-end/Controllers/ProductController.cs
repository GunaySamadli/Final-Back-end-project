using Mejuri_Back_end.Models;
using Mejuri_Back_end.ViewModels;
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
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProductController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id, Review review/*,Question question*/)
        {
            Product product = _context.Products
                .Include(x => x.ProductColors).ThenInclude(x => x.ProductColorImages)
                .Include(x => x.ProductColors).ThenInclude(x => x.Color).FirstOrDefault(x => x.Id == id);

            ShopViewModel shopVM = new ShopViewModel
            {
                Product = product,
                Reviews = _context.Reviews.Include(x => x.AppUser).Where(x => x.ProductId == id).ToList(),
                //Questions=_context.Questions.Include(x=>x.AppUser).Where(x=>x.ProductId==id).ToList()
            };

            return View(shopVM);
        }

        public IActionResult AddToBasket(int id)
        {
            ProductColor product = _context.ProductColors.Include(x=>x.Product).Include(x=>x.ProductColorImages)
                .FirstOrDefault(x => x.Id == id);
            BasketItemViewModel basketItem = null;

            if (product == null) return RedirectToAction("error","index");

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }
            List<BasketItemViewModel> products = new List<BasketItemViewModel>();

            if (member == null)
            {
                string productsStr;

                if (HttpContext.Request.Cookies["Products"] != null)
                {
                    productsStr = HttpContext.Request.Cookies["Products"];
                    products = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(productsStr);

                    basketItem = products.FirstOrDefault(x => x.ProductColorId == id);
                }

                if (basketItem == null)
                {
                    basketItem = new BasketItemViewModel
                    {
                        ProductColorId = product.Id,
                        Name = product.Product.Name,
                        Image = product.ProductColorImages.FirstOrDefault(x => x.PosterStatus == true).Image,
                        Price = product.Product.SalePrice,
                        Count = 1
                    };
                    products.Add(basketItem);
                }
                else
                {
                    basketItem.Count++;
                }
                productsStr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("Products", productsStr);
            }
            else
            {
                BasketItem memberBasketItem = _context.BasketItems.FirstOrDefault(x => x.AppUserId == member.Id && x.ProductColorId == id);
                if (memberBasketItem == null)
                {
                    memberBasketItem = new BasketItem
                    {
                        AppUserId = member.Id,
                        ProductColorId = id,
                        Count = 1
                    };
                    _context.BasketItems.Add(memberBasketItem);
                }
                else
                {
                    memberBasketItem.Count++;
                }

                _context.SaveChanges();
                products = _context.BasketItems.Where(x=>x.AppUserId == member.Id).Select(x =>
                  new BasketItemViewModel
                  {
                      ProductColorId = x.ProductColorId,
                      Count = x.Count,
                      Name = x.ProductColor.Product.Name,
                      Price = x.ProductColor.Product.SalePrice,
                      Image = x.ProductColor.ProductColorImages.FirstOrDefault(bi => bi.PosterStatus == true).Image
                  }).ToList();
            }

            return PartialView("_BasketPartial", products);

        }

        public IActionResult ShowBasket()
        {
            var ProductsSr = HttpContext.Request.Cookies["Products"];
            return Content(ProductsSr);
        }


        public IActionResult DeleteFromBasket(int id)
        {
            ProductColor product = _context.ProductColors.Include(x => x.Product).Include(x => x.ProductColorImages)
                 .FirstOrDefault(x => x.Id == id);

            BasketItemViewModel basketItem = null;

            if (product == null) return RedirectToAction("error", "index");

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<BasketItemViewModel> products = new List<BasketItemViewModel>();

            if (member == null)
            {

                string productsStr = HttpContext.Request.Cookies["Products"];
                products = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(productsStr);

                basketItem = products.FirstOrDefault(x => x.ProductColorId == id);


                if (basketItem.Count == 1)
                {

                    products.Remove(basketItem);
                }
                else
                {
                    basketItem.Count--;
                }
                productsStr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("Products", productsStr);
            }

            else
            {
                BasketItem memberBasketItem = _context.BasketItems.Include(x => x.ProductColor).ThenInclude(x=>x.Product).Include(x => x.ProductColor).ThenInclude(x => x.ProductColorImages).FirstOrDefault(x => x.AppUserId == member.Id && x.ProductColorId == id);

                if (memberBasketItem.Count == 1)
                {

                    _context.BasketItems.Remove(memberBasketItem);
                }
                else
                {
                    memberBasketItem.Count--;
                }

                _context.SaveChanges();

                products = _context.BasketItems.Include(x => x.ProductColor).ThenInclude(bi => bi.ProductColorImages).Where(x => x.AppUserId == member.Id)
                    .Select(x => new BasketItemViewModel { ProductColorId = x.ProductColorId, Count = x.Count, Name = x.ProductColor.Product.Name, Price = x.ProductColor.Product.SalePrice, Image = x.ProductColor.ProductColorImages.FirstOrDefault(b => b.PosterStatus == true).Image }).ToList();

            }
            return PartialView("_BasketPartial",products );
        }


        public IActionResult AddToFav(int id)
        {
            ProductColor product = _context.ProductColors.Include(x => x.Product).Include(x => x.ProductColorImages)
                .FirstOrDefault(x => x.Id == id);
            FavoryItemViewModel favItem = null;

            if (product == null) return NotFound();

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<FavoryItemViewModel> products = new List<FavoryItemViewModel>();

            if (member == null)
            {
                string ProductStr;

                if (HttpContext.Request.Cookies["Favory"] != null)
                {
                    ProductStr = HttpContext.Request.Cookies["Favory"];
                    products = JsonConvert.DeserializeObject<List<FavoryItemViewModel>>(ProductStr);

                    favItem = products.FirstOrDefault(x => x.ProductColorId == id);
                }

                if (favItem == null)
                {
                    favItem = new FavoryItemViewModel
                    {
                        ProductColorId = product.Id,
                        Name = product.Product.Name,
                        Image = product.ProductColorImages.FirstOrDefault(x => x.PosterStatus == true).Image,
                        Price = product.Product.SalePrice
                    };
                    products.Add(favItem);
                }

                ProductStr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("Favory", ProductStr);

            }
            else
            {
                FavoryItem memberFavItem = _context.FavoryItems
                                        .FirstOrDefault(x => x.AppUserId == member.Id && x.ProductColorId == id);
                if (memberFavItem == null)
                {
                    memberFavItem = new FavoryItem
                    {
                        AppUserId = member.Id,
                        ProductColorId = id,
                        Count=1
                    };
                    _context.FavoryItems.Add(memberFavItem);
                }

                _context.SaveChanges();
                products = _context.FavoryItems.Select(x =>
                  new FavoryItemViewModel
                  {
                      ProductColorId = x.ProductColorId,
                      Name = x.ProductColor.Product.Name,
                      Price = x.ProductColor.Product.SalePrice,
                      Image = x.ProductColor.ProductColorImages
                                .FirstOrDefault(bi => bi.PosterStatus == true).Image
                  }).ToList();
            }
            return RedirectToAction("index", "favory", products);


        }


        public IActionResult DeleteFromFav(int id)
        {

            ProductColor product = _context.ProductColors.Include(x => x.ProductColorImages).Include(x => x.Product).FirstOrDefault(x => x.Id == id);
            FavoryItemViewModel favItem = null;

            if (product == null) return RedirectToAction("index", "error");

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<FavoryItemViewModel> products = new List<FavoryItemViewModel>();


            if (member == null)
            {
                string ProductStr = HttpContext.Request.Cookies["Favory"];
                products = JsonConvert.DeserializeObject<List<FavoryItemViewModel>>(ProductStr);

                favItem = products.FirstOrDefault(x => x.ProductColorId == id);



                products.Remove(favItem);


                ProductStr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("Favory", ProductStr);
            }
            else
            {
                FavoryItem memberFavItem = _context.FavoryItems.Include(x => x.ProductColor).ThenInclude(bi => bi.ProductColorImages).Include(x => x.ProductColor).ThenInclude(bi => bi.Product).FirstOrDefault(x => x.AppUserId == member.Id && x.ProductColorId == id);

                _context.FavoryItems.Remove(memberFavItem);

                _context.SaveChanges();

                products = _context.FavoryItems.Include(x => x.ProductColor).ThenInclude(bi => bi.ProductColorImages).Include(x => x.ProductColor).ThenInclude(bi => bi.Product).Where(x => x.AppUserId == member.Id)
                   .Select(x => new FavoryItemViewModel { ProductColorId = x.ProductColorId, Name = x.ProductColor.Product.Name, Price = x.ProductColor.Product.SalePrice, Image = x.ProductColor.ProductColorImages.FirstOrDefault(b => b.PosterStatus == true).Image }).ToList();

            }

            return PartialView("_FavPartial", products);

        }

    }
}
