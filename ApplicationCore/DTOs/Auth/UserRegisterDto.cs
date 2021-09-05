using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs.Auth
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(30, ErrorMessage = "First name cannot be longer than 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(15, ErrorMessage = "Last name cannot be longer than 15 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Nick name is required")]
        [MaxLength(8, ErrorMessage = "Nick name cannot be longer than 8 characters")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50, ErrorMessage = "Email cannot be longer than 50 characters")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(255, ErrorMessage = "Password cannot be longer than 255 characters")]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birthdate is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Role ID is required")]
        public int RoleId { get; set; }

    }
}
