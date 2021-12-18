using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? ProductColorId { get; set; }
        public int Count { get; set; }
        [StringLength(maximumLength: 100)]
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public double DiscountPrice { get; set; }

        public ProductColor ProductColor { get; set; }
        public Order Order { get; set; }
    }
}
