using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qlthucung.Models
{
    public class SignIn
    {
        [Required]
        [Display(Name ="Ten Tai Khoan")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Mat Khau")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Ghi Nho")]
        public bool RememberMe { get; set; }
    }
}
