using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool Accept { get; set; }
        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
    }
}
