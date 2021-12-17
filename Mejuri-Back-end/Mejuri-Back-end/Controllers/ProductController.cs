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
        public IActionResult Detail(int id)
        {
            ShopViewModel shopVM = new ShopViewModel
            {

                Product = _context.Products
                .Include(x=>x.ProductColors).ThenInclude(x=>x.ProductColorImages)
                .Include(x=>x.ProductColors).ThenInclude(x=>x.Color)
                .Include(x => x.ProductMaterials).ThenInclude(x => x.Material).Where(x=>x.Id==id).FirstOrDefault()


            };
           
            return View(shopVM);
        }

        public IActionResult AddToBasket(int id)
        {
            Product product = _context.Products.Include(x => x.ProductColors).ThenInclude(x=>x.ProductColorImages)
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

                    basketItem = products.FirstOrDefault(x => x.ProductId == id);
                }

                if (basketItem == null)
                {
                    basketItem = new BasketItemViewModel
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Image = product.ProductColors.FirstOrDefault().ProductColorImages.FirstOrDefault(x => x.PosterStatus == true).Image,
                        Price = product.SalePrice,
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
                BasketItem memberBasketItem = _context.BasketItems.FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);
                if (memberBasketItem == null)
                {
                    memberBasketItem = new BasketItem
                    {
                        AppUserId = member.Id,
                        ProductId = id,
                        Count = 1
                    };
                    _context.BasketItems.Add(memberBasketItem);
                }
                else
                {
                    memberBasketItem.Count++;
                }

                _context.SaveChanges();
                products = _context.BasketItems.Select(x =>
                  new BasketItemViewModel
                  {
                      ProductId = x.ProductId,
                      Count = x.Count,
                      Name = x.Product.Name,
                      Price = x.Product.SalePrice,
                      Image = x.Product.ProductColors.FirstOrDefault().ProductColorImages.FirstOrDefault(bi => bi.PosterStatus == true).Image
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
            Product product = _context.Products.Include(x => x.ProductColors).ThenInclude(x => x.ProductColorImages)
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

                basketItem = products.FirstOrDefault(x => x.ProductId == id);


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
                BasketItem memberBasketItem = _context.BasketItems.Include(x => x.Product).ThenInclude(x => x.ProductColors).ThenInclude(x => x.ProductColorImages).FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);

                if (memberBasketItem.Count == 1)
                {

                    _context.BasketItems.Remove(memberBasketItem);
                }
                else
                {
                    memberBasketItem.Count--;
                }

                _context.SaveChanges();

                products = _context.BasketItems.Include(x => x.Product).ThenInclude(bi => bi.ProductColors).ThenInclude(bi => bi.ProductColorImages).Where(x => x.AppUserId == member.Id)
                    .Select(x => new BasketItemViewModel { ProductId = x.ProductId, Count = x.Count, Name = x.Product.Name, Price = x.Product.SalePrice, Image = x.Product.ProductColors.FirstOrDefault().ProductColorImages.FirstOrDefault(b => b.PosterStatus == true).Image }).ToList();

            }
            return PartialView("_BasketPartial",products );
        }
    }
}
