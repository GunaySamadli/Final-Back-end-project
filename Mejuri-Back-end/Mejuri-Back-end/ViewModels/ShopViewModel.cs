using Mejuri_Back_end.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.ViewModels
{
    public class ShopViewModel
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductMaterial> ProductMaterials { get; set; }
        public List<Material> Materials { get; set; }
        public List<Category> Categories { get; set; }
        public List<Gender> Genders { get; set; }
        public List<Review> Reviews { get; set; }
        public Review Review { get; set; }

    }
}
