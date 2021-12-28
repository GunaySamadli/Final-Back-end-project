using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class Faq
    {
        public int Id { get; set; }

        public int Order { get; set; }
        [Required]
        [StringLength(maximumLength: 250)]
        public string Question { get; set; }
        [Required]
        [StringLength(maximumLength: 2500)]
        public string Answer { get; set; }
    }
}
