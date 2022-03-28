using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModels
{
    public class AdminUserManagement
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string RegistrationDate { get; set; }
        public int UserType { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public List<string> UserNameList { get; set; }

        public List<AdminUserManagement> User { get; set; }
    }
}
