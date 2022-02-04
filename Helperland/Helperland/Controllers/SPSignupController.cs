using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models.ViewModels;
using Helperland.Models.Data;
using System.Web.Helpers;

namespace Helperland.Controllers
{
    public class SPSignupController : Controller
    {
        public readonly HelperlandContext _helperlandContext = null;
        public SPSignupController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }

        [Route("/sp-signup")]
        public IActionResult SPSignup()
        {
            return View();
        }

        [Route("/sp-signup")]
        [HttpPost]
        public IActionResult SPSignup(RegistrationModel registrationModel)
        {
            var isExist = _helperlandContext.Users.Where(x => x.Email.Equals(registrationModel.Email)).FirstOrDefault();

            var passwordHash = Crypto.HashPassword(registrationModel.Password);

            User user = new User()
            {
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                Email = registrationModel.Email,
                Password = passwordHash,
                Mobile = registrationModel.Mobile,
                UserTypeId = 2,
                IsRegisteredUser = false,
                WorksWithPets = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = 2,
                IsApproved = false,
                IsActive = false,
                IsDeleted = false,
            };

            _helperlandContext.Users.Add(user);
            _helperlandContext.SaveChanges();
            return RedirectToAction("SPSignup");
        }
    }
}
