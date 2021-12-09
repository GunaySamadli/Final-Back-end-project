using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.ViewModels
{
    public class LoginViewModel
    {
        [StringLength(maximumLength:50,MinimumLength =6,ErrorMessage = "UserName must be a string with a min length of 6 and a max length of 50.")]
        public string UserName { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 6,ErrorMessage = "Password must be a string with a min length of 6 and a max length of 30.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPersistent { get; set; } = false;

    }
}
