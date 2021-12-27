using Mejuri_Back_end.Models;
using Mejuri_Back_end.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public OrderController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Orders.Include(x => x.OrderItems).AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.FullName.Contains(search));
            }

            List<Order> orders = query
               .Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;

            return View(orders);
        }

        public IActionResult Edit(int id)
        {
            Order order = _context.Orders.Include(x => x.OrderItems).FirstOrDefault(x => x.Id == id);

            if (order == null) return RedirectToAction("index", "error");

            return View(order);
        }

        public IActionResult Accept(int id)
        {
            Order order = _context.Orders.Include(x=>x.OrderItems).Include(x=>x.AppUser).FirstOrDefault(x => x.Id == id);
            if (order == null) return RedirectToAction("index", "error");

            order.Status = Models.Enums.OrderStatus.Accepted;
            _context.SaveChanges();

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/templates/order.html"))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{{total}}", order.TotalAmount.ToString());

            string orderItems = string.Empty;

            foreach (var item in order.OrderItems)
            {
                string tr = @$"<tr>
                     <td width=\""75 %\"" align=\""left\"" style =\""font - family: Open Sans, Helvetica, Arial, sans-serif; font - size: 16px; font - weight: 400; line - height: 24px; padding: 15px 10px 5px 10px;\"" > {item.ProductName} </td>
                     <td width=\""25 %\"" align=\""left\"" style =\""font - family: Open Sans, Helvetica, Arial, sans-serif; font - size: 16px; font - weight: 400; line - height: 24px; padding: 15px 10px 5px 10px;\"" > {item.Count}X{item.SalePrice} </td>
                </tr>";

                orderItems += tr;
            }

            body = body.Replace("{{total}}", order.TotalAmount.ToString()).Replace("{{orderItems}}", orderItems);


            _emailService.Send(order.AppUser.Email, "Order accepted", body);
            return RedirectToAction("index");
        }


        public IActionResult Reject(int id)
        {
            Order order = _context.Orders.Include(x => x.OrderItems).FirstOrDefault(x => x.Id == id);
            if (order == null) return NotFound();

            order.Status = Models.Enums.OrderStatus.Rejected;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
