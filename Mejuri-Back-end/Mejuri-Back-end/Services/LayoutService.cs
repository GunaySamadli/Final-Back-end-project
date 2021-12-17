using Mejuri_Back_end.Models;
using Mejuri_Back_end.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }



        public List<BasketItemViewModel> GetBasketItems()
        {
            List<BasketItemViewModel> items = new List<BasketItemViewModel>();

            AppUser member = null;
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == _contextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }


            if (member == null)
            {
                var itemsStr = _contextAccessor.HttpContext.Request.Cookies["Products"];

                if (itemsStr != null)
                {
                    items = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(itemsStr);

                    foreach (var item in items)
                    {
                        Product product = _context.Products.Include(c => c.ProductColors).ThenInclude(c=>c.ProductColorImages).FirstOrDefault(x => x.Id == item.ProductId);
                        if (product != null)
                        {
                            item.Name = product.Name;
                            item.Price = product.SalePrice;
                            item.Image = product.ProductColors.FirstOrDefault().ProductColorImages.FirstOrDefault(x => x.PosterStatus == true)?.Image;

                        }
                    }
                }
            }
            else
            {
                List<BasketItem> basketItems = _context.BasketItems.Include(x => x.Product).ThenInclude(x => x.ProductColors).ThenInclude(x=>x.ProductColorImages).Where(x => x.AppUserId == member.Id).ToList();
                items = basketItems.Select(x => new BasketItemViewModel
                {
                    ProductId = x.ProductId,
                    Count = x.Count,
                    Image = x.Product.ProductColors.FirstOrDefault().ProductColorImages.FirstOrDefault(bi => bi.PosterStatus == true)?.Image,
                    Name = x.Product.Name,
                    Price = x.Product.SalePrice
                }).ToList();
            }

            return items;
        }




    }

}
