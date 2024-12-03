using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qlthucung.Models
{
    public class Register
    {
        [Required]
        [Display(Name = "Ten Tai Khoan")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Mat Khau")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [Display(Name = "Nhap Lai Mat Khau")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Ho Ten")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Ngay sinh")]
        public DateTime BirthDate { get; set; }
        
    }
}
