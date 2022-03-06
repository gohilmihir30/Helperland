using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Helperland.Models.ViewModels
{
    public class ServiceRatingModel
    { 
        public int UserId { get; set; }
        public int? ServicProviderId { get; set; }
        public string Profile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ServiceRequestId { get; set; }
        public string Comments { get; set; }
        [Required]
        public decimal OnTimeArrival { get; set; }
        [Required]
        public decimal Friendly { get; set; }
        [Required]
        public decimal QualityOfService { get; set; }
        public decimal Ratings { get; set; }
    }
}