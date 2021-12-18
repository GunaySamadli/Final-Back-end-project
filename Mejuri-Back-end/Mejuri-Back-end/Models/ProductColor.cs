using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class ProductColor
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public Product Product { get; set; }
        public Color Color { get; set; }

        public List<ProductColorImage> ProductColorImages { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public List<BasketItem> BasketItems { get; set; }


        [NotMapped]
        public IFormFile PosterFile { get; set; }
        [NotMapped]
        public IFormFile HoverFile { get; set; }
        [NotMapped]
        public List<IFormFile> ImagesFile { get; set; }
        [NotMapped]
        public List<int> ImageIds { get; set; } = new List<int>();


    }
}
