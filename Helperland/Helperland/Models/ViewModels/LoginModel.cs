using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Helperland.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please Enter Email")]
        [EmailAddress(ErrorMessage ="Enter valid Email")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please enter Password")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{6,14}$",
            ErrorMessage = "You must enter At least one upper case, one lower case, one digit and Minimum eight and Maximum Fourteen in length")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        [Required(ErrorMessage ="Please enter Email")]
        [EmailAddress(ErrorMessage ="Enter valid Email")]
        [Remote(controller:"Home",action: "IsEmailInUse")]
        public string Email { get; set; }
    }
}
