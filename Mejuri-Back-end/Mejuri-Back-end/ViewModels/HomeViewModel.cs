using Mejuri_Back_end.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.ViewModels
{
    public class HomeViewModel
    {
       public List<Brand> Brands { get; set; }
       public List<Slider> Sliders { get; set; }
       public List<Category> Categories { get; set; }
       public List<CompanyCategory> CompanyCategories { get; set; }
       public List<Company> Companies { get; set; }
        public List<Product> Products { get; set; }

        public List<ProductColor> ProductColors { get; set; }
        public List<ProductColorImage> ProductColorImages { get; set; }


    }
}
