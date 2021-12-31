using Mejuri_Back_end.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.ViewModels
{
    public class DashboardViewModel
    {
        public List<Order> Orders { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
