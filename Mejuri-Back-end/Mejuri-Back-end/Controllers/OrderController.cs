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
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Member")]
        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.Include(x => x.OrderItems).Where(x => x.AppUser.UserName == User.Identity.Name).ToList();
            return View(orders);
        }

        public IActionResult Checkout()
        {
            CheckoutViewModel checkoutVM = new CheckoutViewModel();

            AppUser member = null;
            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
                var productsStr = HttpContext.Request.Cookies["Products"];
                if (!string.IsNullOrWhiteSpace(productsStr))
                {
                    checkoutVM.BasketItemViewModels = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(productsStr);

                    foreach (var item in checkoutVM.BasketItemViewModels)
                    {
                        ProductColor product = _context.ProductColors.Include(x=>x.Color)
                            .Include(x=>x.Product).Include(x => x.ProductColorImages).FirstOrDefault(x => x.Id == item.ProductColorId);
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
                checkoutVM.Email = member.Email;
                checkoutVM.FullName = member.FullName;
                checkoutVM.Phone = member.PhoneNumber;

                checkoutVM.BasketItemViewModels = _context.BasketItems.Include(x => x.ProductColor).Where(x => x.AppUserId == member.Id)
                                                   .Select(x => new BasketItemViewModel
                                                   {
                                                       ProductColorId = x.ProductColorId,
                                                       Name = x.ProductColor.Product.Name,
                                                       ColorName=x.ProductColor.Color.Name,
                                                       Count = x.Count,
                                                       Price = x.ProductColor.Product.SalePrice
                                                   }).ToList();

            }

            return View(checkoutVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutViewModel checkoutVM)
        {
            checkoutVM.BasketItemViewModels = _getBasketItems();
            if (!ModelState.IsValid) return View(checkoutVM);

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            Order order = new Order
            {
                FullName = checkoutVM.FullName,
                Email = checkoutVM.Email,
                Address = checkoutVM.Address,
                City = checkoutVM.City,
                Phone = checkoutVM.Phone,
                Status = Models.Enums.OrderStatus.Pending,
                ZipCode = checkoutVM.ZipCode,
                CreatedAt = DateTime.UtcNow,
                OrderItems = new List<OrderItem>()
            };

            List<BasketItemViewModel> basketItemVMs = new List<BasketItemViewModel>();

            if (member == null)
            {
                var productsStr = HttpContext.Request.Cookies["Products"];
                if (productsStr != null)
                {
                    basketItemVMs = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(productsStr);
                }
            }
            else
            {
                order.AppUserId = member.Id;
                basketItemVMs = _context.BasketItems.Where(x => x.AppUserId == member.Id).Select(x => new BasketItemViewModel { ProductColorId = x.ProductColorId, Count = x.Count }).ToList();
            }

            foreach (var item in basketItemVMs)
            {
                ProductColor productColor = _context.ProductColors.Include(x=>x.Color)
                    .Include(x=>x.Product).FirstOrDefault(x => x.Id == item.ProductColorId);

                if (productColor == null)
                {
                    ModelState.AddModelError("", "Selected product not found");
                    return View(checkoutVM);
                }

                _addOrderItem(ref order, productColor, item.Count);
            }

            if (order.OrderItems.Count == 0)
            {
                ModelState.AddModelError("", "there is not any selected product!");
                return View(checkoutVM);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            if (member == null)
            {
                Response.Cookies.Delete("Products");
            }
            else
            {
                _context.BasketItems.RemoveRange(_context.BasketItems.Where(x => x.AppUserId == member.Id));
                _context.SaveChanges();
            }

            return RedirectToAction("index", "home");
        }


        private void _addOrderItem(ref Order order, ProductColor productColor, int count)
        {
            OrderItem orderItem = new OrderItem
            {
                ProductColorId = productColor.Id,
                ProductName = productColor.Product.Name,
                SalePrice = productColor.Product.SalePrice,
                ColorName=productColor.Color.Name,
                Count = count,
            };

            order.OrderItems.Add(orderItem);
            order.TotalAmount += (orderItem.SalePrice - orderItem.DiscountPrice) * orderItem.Count;
        }
        private List<BasketItemViewModel> _getBasketItems()
        {
            List<BasketItemViewModel> basketItems = new List<BasketItemViewModel>();
            AppUser member = null;
            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
                var productsStr = HttpContext.Request.Cookies["Products"];
                if (!string.IsNullOrWhiteSpace(productsStr))
                {
                    basketItems = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(productsStr);

                    foreach (var item in basketItems)
                    {
                        ProductColor product = _context.ProductColors.Include(x=>x.Color)
                            .Include(x => x.Product).Include(x => x.ProductColorImages).FirstOrDefault(x => x.Id == item.ProductColorId);
                        if (product != null)
                        {
                            item.Name = product.Product.Name;
                            item.ColorName = product.Color.Name;
                            item.Price = product.Product.SalePrice;
                            item.Image = product.ProductColorImages.FirstOrDefault(x => x.PosterStatus == true)?.Image;
                        }
                    }
                }
            }
            else
            {

                basketItems = _context.BasketItems.Include(x => x.ProductColor).ThenInclude(x => x.Color)
                    .Include(x => x.ProductColor).ThenInclude(x => x.Product).Where(x => x.AppUserId == member.Id)
                                                    .Select(x => new BasketItemViewModel
                                                    {
                                                        ProductColorId = x.ProductColorId,
                                                        Name = x.ProductColor.Product.Name,
                                                        ColorName=x.ProductColor.Color.Name,
                                                        Count = x.Count,
                                                        Price = x.ProductColor.Product.SalePrice
                                                    }).ToList();

            }
            return basketItems;
        }


    }
}
