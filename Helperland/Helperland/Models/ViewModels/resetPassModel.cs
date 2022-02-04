using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Helperland.Models.ViewModels
{
    public class resetPassModel
    {
        [Required(ErrorMessage = "Please enter a Password")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{6,14}$",
                    ErrorMessage = "You must enter At least one upper case, one lower case, one digit, one special character, Minimum 6 and Maximum 14 in length.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please enter confirm password!")]
        [Compare("NewPassword", ErrorMessage = "Password does not match the confirm password!")]
        public string ConfirmPassword { get; set; }
    }
}
