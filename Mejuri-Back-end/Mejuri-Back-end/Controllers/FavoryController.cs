using Mejuri_Back_end.Models;
using Mejuri_Back_end.ViewModels;
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
    public class FavoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;
        public FavoryController(AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<FavoryItemViewModel> items = new List<FavoryItemViewModel>();

            AppUser member = null;

            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == _contextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }


            if (member == null)
            {
                var itemsStr = _contextAccessor.HttpContext.Request.Cookies["Favory"];

                if (itemsStr != null)
                {
                    items = JsonConvert.DeserializeObject<List<FavoryItemViewModel>>(itemsStr);

                    foreach (var item in items)
                    {
                        ProductColor product = _context.ProductColors.Include(x=>x.Color)
                            .Include(c => c.ProductColorImages).Include(x=>x.Product).FirstOrDefault(x => x.Id == item.ProductColorId);

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

            return View(items);
        }
    }
}
