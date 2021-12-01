﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string Name { get; set; }
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }

    }
}
