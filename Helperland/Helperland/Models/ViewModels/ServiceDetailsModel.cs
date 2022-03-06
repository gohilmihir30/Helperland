using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModels
{
    public class ServiceDetailsModel
    {
        public int ServiceId { get; set; }
        public DateTime ServiceStartTime { get; set; }
        public double ServiceHours { get; set; }
        public decimal TotalCost { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int? ServiceProviderId { get; set; }
        public string FirstNamme { get; set; }
        public string LastName { get; set; }
        public string Profile { get; set; }
        public int TotalCleaning { get; set; }
        public decimal AverageRating { get; set; }
        public string Comments { get; set; }
        public List<string> extra { get; set; } = new List<string>();
    }
}