using System;
using System.ComponentModel.DataAnnotations;

namespace PasswordHashedLoginWebApp.Controllers
{
    public class LoginVM
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}