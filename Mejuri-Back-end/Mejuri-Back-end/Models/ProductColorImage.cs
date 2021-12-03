using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class ProductColorImage
    {
        public int Id { get; set; }
        public int ProductColorId { get; set; }

        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        public bool? PosterStatus { get; set; }

        public ProductColor ProductColor { get; set; }

    }
}
