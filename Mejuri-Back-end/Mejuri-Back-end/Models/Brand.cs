using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 150)]
        public string Text { get; set; }
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
    }
}
