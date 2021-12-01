using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }
        [StringLength(maximumLength: 50)]
        public string SubTitle { get; set; }
        [StringLength(maximumLength: 100)]
        public string RedirectUrl { get; set; }
        [StringLength(maximumLength: 50)]
        public string RedirectUrlText { get; set; }


    }
}
