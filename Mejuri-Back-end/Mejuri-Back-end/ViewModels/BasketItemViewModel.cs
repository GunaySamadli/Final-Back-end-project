using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.ViewModels
{
    public class BasketItemViewModel
    {
        public int ProductColorId { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string ColorName { get; set; }

        public bool IsStock { get; set; }
        public int Count { get; set; }
    }
}
