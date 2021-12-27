using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Icon { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string SubTitle { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string RedirectUrlText { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string RedirectUrl{ get; set; }



    }
}
