using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public Category Category { get; set; }
        public Gender Gender { get; set; }
        public List<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
        public List<ProductMaterial> ProductMaterials { get; set; } = new List<ProductMaterial>();

        public List<Company> Companies { get; set; }

        [NotMapped]
        public IFormFile PosterFile { get; set; }

        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }

        [NotMapped]
        public List<int> ColorIds { get; set; } = new List<int>();

        [NotMapped]
        public List<int> MaterialIds { get; set; } = new List<int>();


    }
}
