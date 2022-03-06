using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Helperland.Models.ViewModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage ="Please enter a First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Please enter a Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Please enter an Email Address.")]
        [EmailAddress(ErrorMessage ="Please enter a valid Email")]
        [Remote(action: "IsEmailInUse", controller: "Customer")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter a Password")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{6,14}$",
            ErrorMessage = "You must enter At least one upper case, one lower case, one digit, one special character, Minimum 6 and Maximum 14 in length.")]
        public string Password { get; set; }
        [Required (ErrorMessage = "Please enter confirm password!")]
        [Compare("Password",ErrorMessage = "Password does not match the confirm password!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Please enter a Mobile Number")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Enter valid Phone Number")]
        public string Mobile { get; set; }
    }
}
