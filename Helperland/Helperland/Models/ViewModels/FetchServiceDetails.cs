using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models.ViewModels;
namespace Helperland.Models.ViewModels
{
    public class FetchServiceDetails
    {
        public IEnumerable<FetchServiceDetails> Details { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public DateTime ServiceStartTime { get; set; }
        public double ServiceHours { get; set; }
        public decimal TotalCost { get; set; }
        public string Profile { get; set; }
        public int? ServiceProviderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comment {get; set;}
        public decimal AverageRating { get; set; }
        public decimal OnTimeArrival { get; set; }
        public decimal Friendly { get; set; }
        public Guid? RecordVersion { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public decimal QualityOfService { get; set; }
        public int? Status { get; set; }

    }
}
