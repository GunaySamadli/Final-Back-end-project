using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class Company
    {
        public int Id { get; set; }
        public int CompanyCategoryId { get; set; }
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [StringLength(maximumLength: 100)]
        public string Title { get; set; }
        [Required]
        public int Percent { get; set; }

        public CompanyCategory CompanyCategory { get; set; }
        public List<Product> Products { get; set; }



    }
}
