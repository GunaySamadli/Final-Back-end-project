using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class Gender
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string Name { get; set; }

    }
}
