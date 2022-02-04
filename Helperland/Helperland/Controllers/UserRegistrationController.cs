using Helperland.Models.ViewModels;
using Helperland.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Helperland.Controllers
{
    public class UserRegistrationController : Controller
    {
        public HelperlandContext _helperlandContext = null;

        public UserRegistrationController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }

        [Route("/userRegistration")]
        [HttpGet]
        public ActionResult userRegistration()
        {
            return View();
        }


        [Route("/userRegistration")]
        [HttpPost]
        public ActionResult UserRegistration(RegistrationModel registrationModel)
        {
            var isExist = _helperlandContext.Users.Where(x => x.Email.Equals(registrationModel.Email)).FirstOrDefault();

            var passwordHash = Crypto.HashPassword(registrationModel.Password);

            User user = new User()
            {
                FirstName=registrationModel.FirstName,
                LastName=registrationModel.LastName,
                Email=registrationModel.Email,
                Password=passwordHash,
                Mobile=registrationModel.Mobile,
                UserTypeId=1,
                IsRegisteredUser=false,
                WorksWithPets=false,
                CreatedDate=DateTime.Now,
                ModifiedDate=DateTime.Now,
                ModifiedBy=1,
                IsApproved=true,
                IsActive=true,
                IsDeleted=false,
            };

            _helperlandContext.Users.Add(user);
            _helperlandContext.SaveChanges();

            return RedirectToAction("userRegistration");
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsEmailInUse(string email) =>
         _helperlandContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault() == null ? Json(true) : Json($"Email already exist");
    }
}
