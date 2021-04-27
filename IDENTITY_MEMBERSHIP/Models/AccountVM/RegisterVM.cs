using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDENTITY_MEMBERSHIP.Models.AccountVM
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Please enter username!")]
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters!")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your first name!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address!")]
        [EmailAddress(ErrorMessage = "E-mail address is not valid!")]
        [Display(Name = "E-mail Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Pleaseconfirm your password!")]
        [Display(Name = "Password Again")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}