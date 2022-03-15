using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Helperland.Models.ViewModels
{
    public class MyAccountModel
    {
        [Required(ErrorMessage ="Enter First Name")]
        public string FirstName { get; set;}
        [Required(ErrorMessage ="Enter Last Name")]
        public string LastName { get; set;}
        [Required(ErrorMessage ="Enter Email Address")]
        public string Email { get; set;}
        [Required(ErrorMessage ="Enter Mobile Number")]
        [RegularExpression("[0-9]{10}",ErrorMessage ="Enter valid mobile number")]
        public string Mobile { get; set;}
        [Required(ErrorMessage = "Select Preferred language")]
        public int? LanguageId { get; set;}
        [Required (ErrorMessage ="Select your Nation")]
        public int? NatinalityId { get; set; }
        [Required(ErrorMessage ="Select Gender")]
        public int? Gender { get; set; }
        [Required (ErrorMessage ="Select your Avatar")]
        public string Avatar { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int? Day { get; set;}
        [Required]
        public int? Month { get; set;}
        [Required]
        public int? Year { get; set;}
        public AddressModel address { get; set; }
        [Required (ErrorMessage ="Enter Old Password")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{6,14}$",
            ErrorMessage = "You must enter At least one upper case, one lower case, one digit, one special character, Minimum 6 and Maximum 14 in length.")]
        public string OldPassword { get; set; }
        [Required (ErrorMessage ="Enter New Password")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{6,14}$",
            ErrorMessage = "You must enter At least one upper case, one lower case, one digit, one special character, Minimum 6 and Maximum 14 in length.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage ="Enter Confirm Password")]
        [Compare("NewPassword",ErrorMessage = "Password does not match the confirm password!")]
        public string ConfirmPassword { get; set; }
    }

    public class AddressModel
    {
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Plase enter Street name")]
        public string AddressLine1 { get; set; }
        [Required(ErrorMessage = "Please enter House number")]
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage ="Plese Enter Postal Code")]
        public string PostalCode { get; set; }
        [Required (ErrorMessage ="Postal code does not exist in our database please enter different postalcode")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter Mobile number")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Enter valid Phone Number")]
        public string Mobile { get; set; }
    }
}
