using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasswordHashedLoginWebApp.Models
{
    public class SignUpVM
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}