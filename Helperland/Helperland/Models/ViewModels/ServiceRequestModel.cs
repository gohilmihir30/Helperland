using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Helperland.Models.ViewModels
{
    public class ServiceRequestModel
    {
        [Required(ErrorMessage = "Please enter a postal code")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Postalcode must be digit and length must be five.")]
        [MinLength(5, ErrorMessage = "Minimum length 5.")]
        public String Postalcode { get; set; }

        public int UserId { get; set; }
        public string ServiceStartDate { get; set; }
        public int ServiceStartTime { get; set; }
        public double ServiceHours { get; set; }
        public double? ExtraHours { get; set; }
        public decimal? ServiceHourlyRate { get; set; }
        public decimal TotalCost { get; set; }
        public string Comments { get; set; }
        public bool HasPets { get; set; }
        public bool Cabinet { get; set; }
        public bool Fridge { get; set; }
        public bool Oven { get; set; }
        public bool Laundry { get; set; }
        public bool Windows { get; set; }
        public int AddressId { get; set; }
        [Required(ErrorMessage ="Plase enter Street name")]
        public string AddressLine1 { get; set; }
        [Required(ErrorMessage ="Please enter House number")]
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage ="Please enter Mobile number")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Enter valid Phone Number")]
        public string Mobile { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
    }
}
