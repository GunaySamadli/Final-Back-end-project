using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int GenderId { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        [StringLength(maximumLength: 1000)]
        public string Desc { get; set; }
        [Required]
        public int SalePrice { get; set; }
        [Required]
        public int Rate { get; set; }
        public bool IsStock { get; set; }
        public int? ShippingPrice { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<ProductMaterial> ProductMaterials { get; set; }




    }
}
