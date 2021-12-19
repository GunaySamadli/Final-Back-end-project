using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string Email { get; set; }
    }
}
