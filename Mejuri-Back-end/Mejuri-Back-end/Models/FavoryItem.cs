using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class FavoryItem
    {
        public int Id { get; set; }
        public int ProductColorId { get; set; }
        public string AppUserId { get; set; }
        public int Count { get; set; }

        public ProductColor ProductColor { get; set; }
        public AppUser AppUser { get; set; }
    }
}
