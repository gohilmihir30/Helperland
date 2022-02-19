using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Helperland.Models.ViewModels
{
    public class contactUsForm
    {
        public int ContactUsId { get; set; }
        [Required(ErrorMessage = "Please enter a First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter an Email Address")]
        [EmailAddress(ErrorMessage = "Please enter valid Email Address")]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required (ErrorMessage ="Please Enter a Phone Number")]
        [RegularExpression("[0-9]{10}",ErrorMessage ="Enter valid Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter a Message")]
        public string Message { get; set; }
        public IFormFile FilePath { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
    }
}
