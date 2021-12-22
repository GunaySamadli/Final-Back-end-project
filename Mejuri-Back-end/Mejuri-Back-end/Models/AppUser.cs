using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }

        public List<BasketItem> BasketItems { get; set; }
        public List<Review> Reviews { get; set; }
        public List<FavoryItem> FavoryItems { get; set; }
        public List<Question> Questions { get; set; }



    }
}
