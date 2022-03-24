using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModels
{
    public class AdminServiceRequest
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage ="Select Date")]
        public DateTime ServiceStartDate { get; set; }
        public double ServiceHours { get; set; }
        public decimal TotalCost { get; set; }
        public string Cust_firstname { get; set; }
        public string cust_lastname { get; set; }
        [Required(ErrorMessage ="Enter Street Name")]
        public string AddressLine1 { get; set; }
        [Required(ErrorMessage ="Enter Houser Number")]
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage ="Enter Postal Code")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Postal code does not exist in our database please enter different postalcode")]
        public string City { get; set; }
        public List<AdminServiceRequest> serviceRequests { get; set; }
        public List<string> Customers { get; set; }
        public List<string> ServiceProvider { get; set; }
        [Required(ErrorMessage ="Enter reason for refund")]
        public string RefundReason { get; set; }
#nullable enable
        public int? ServiceProviderId { get; set; }
        public string? Profile { get; set; }
        public int? Status { get; set; }
        public string? sp_firstname { get; set; }
        public string? sp_lastname { get; set; }
        public decimal? avgRating { get; set; }
        public string? RescheduleReason { get; set; }
        [Required(ErrorMessage ="Enter Refund Amount")]
        public decimal? RefundAmount { get; set; }
        public string? ServiceStartTime { get; set; }

    }
}
