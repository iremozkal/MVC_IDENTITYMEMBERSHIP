using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IDENTITY_MEMBERSHIP.Models.AccountVM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username cannot be empty!")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty!")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}