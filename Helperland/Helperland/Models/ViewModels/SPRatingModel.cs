using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModels
{
    public class SPRatingModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ServiceId { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public double ServiceHours { get; set; }
        public decimal Rating{ get; set; }
        public string Comments{ get; set; }

        public List<SPRatingModel> spRatingModel { get; set; }
    }
}
