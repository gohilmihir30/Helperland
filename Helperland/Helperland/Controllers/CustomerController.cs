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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Globalization;
using Helperland.Services.Email;

namespace Helperland.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        public HelperlandContext _helperlandContext = null;

        public CustomerController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }

        [Route("/userRegistration")]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult userRegistration()
        {
            return View();
        }

        [Route("/userRegistration")]
        [AllowAnonymous]
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

        [Route("/book-service")]
        public IActionResult BookService()
        {
            var userId = User.FindFirstValue(ClaimTypes.Role);
            return View();
        }
        
        [Route("/book-service")]
        [HttpPost]
        public int BookService(ServiceRequestModel serviceRequestModel)
        {
            var serviceRequest = new ServiceRequest();
            try
            {
                int _random = new Random().Next(1000, 9999);
                var isExist = _helperlandContext.ServiceRequests.Where(x => x.ServiceId == _random).FirstOrDefault();
                while (isExist != null)
                {
                    _random = new Random().Next(1000, 9999);
                    isExist = _helperlandContext.ServiceRequests.Where(x => x.ServiceId == _random).FirstOrDefault();
                }
                var arr = serviceRequestModel.ServiceStartDate.Split('/');

                var hours = Math.Floor(serviceRequestModel.ServiceStartTime);
                var min = Math.Ceiling((serviceRequestModel.ServiceStartTime - hours) * 60);
                var date = new DateTime(Int32.Parse(arr[2]), Int32.Parse(arr[1]), Int32.Parse(arr[0]), (int)hours, (int)min, 0);


                serviceRequest = new ServiceRequest()
                {
                    UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    ServiceId = _random,
                    ServiceStartDate =date,
                    ZipCode = serviceRequestModel.Postalcode,
                    ServiceHourlyRate = serviceRequestModel.ServiceHourlyRate,
                    ServiceHours = serviceRequestModel.ServiceHours,
                    ExtraHours = serviceRequestModel.ExtraHours,
                    TotalCost = serviceRequestModel.TotalCost,
                    Comments = serviceRequestModel.Comments,
                    HasPets = serviceRequestModel.HasPets,
                    Status = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                _helperlandContext.ServiceRequests.Add(serviceRequest);
                _helperlandContext.SaveChanges();

                if (serviceRequestModel.Cabinet)
                {
                    var serviceRequestExtra = new ServiceRequestExtra()
                    {
                        ServiceRequestId = serviceRequest.ServiceRequestId,
                        ServiceExtraId = 1
                    };
                    _helperlandContext.ServiceRequestExtras.Add(serviceRequestExtra);
                }
                if (serviceRequestModel.Fridge)
                {
                    var serviceRequestExtra = new ServiceRequestExtra()
                    {
                        ServiceRequestId = serviceRequest.ServiceRequestId,
                        ServiceExtraId = 2
                    };
                    _helperlandContext.ServiceRequestExtras.Add(serviceRequestExtra);
                }
                if (serviceRequestModel.Oven)
                {
                    var serviceRequestExtra = new ServiceRequestExtra()
                    {
                        ServiceRequestId = serviceRequest.ServiceRequestId,
                        ServiceExtraId = 3
                    };
                    _helperlandContext.ServiceRequestExtras.Add(serviceRequestExtra);
                }
                if (serviceRequestModel.Laundry)
                {
                    var serviceRequestExtra = new ServiceRequestExtra()
                    {
                        ServiceRequestId = serviceRequest.ServiceRequestId,
                        ServiceExtraId = 4
                    };
                    _helperlandContext.ServiceRequestExtras.Add(serviceRequestExtra);
                }
                if (serviceRequestModel.Windows)
                {
                    var serviceRequestExtra = new ServiceRequestExtra()
                    {
                        ServiceRequestId = serviceRequest.ServiceRequestId,
                        ServiceExtraId = 5
                    };
                    _helperlandContext.ServiceRequestExtras.Add(serviceRequestExtra);
                }

                UserAddress userAddress = _helperlandContext.UserAddresses.Where(x => x.AddressId == serviceRequestModel.AddressId[0]).FirstOrDefault();
                var serviceRequestAddress = new ServiceRequestAddress()
                {
                    ServiceRequestId = serviceRequest.ServiceRequestId,
                    AddressLine1 = userAddress.AddressLine1,
                    AddressLine2 = userAddress.AddressLine2,
                    City = userAddress.City,
                    State = userAddress.State,
                    PostalCode = userAddress.PostalCode,
                    Mobile = userAddress.Mobile,
                    Email = userAddress.Email
                };
                _helperlandContext.ServiceRequestAddresses.Add(serviceRequestAddress);
                _helperlandContext.ServiceRequests.Attach(serviceRequest);
                var result= _helperlandContext.SaveChanges();
                
                return serviceRequest.ServiceId;
        }
            catch
            {
                _helperlandContext.ServiceRequests.Remove(_helperlandContext.ServiceRequests.Where(x=>x.ServiceRequestId== serviceRequest.ServiceRequestId).FirstOrDefault());
                _helperlandContext.SaveChanges();
                return 0;
            }
}


        [Route("/check-availability")]
        [HttpPost]
        public JsonResult CheckAvailability(string postalCode)
        {
            if (postalCode != null)
            {
                var isAvailable = _helperlandContext.Users.Where(u => u.UserTypeId == 2 && u.ZipCode == postalCode).FirstOrDefault();
                if (isAvailable != null)
                {
                    var city = (
                        from z in _helperlandContext.Zipcodes
                        join c in _helperlandContext.Cities
                        on z.CityId equals c.Id
                        where z.ZipcodeValue == postalCode
                        select c.CityName
                    ).FirstOrDefault();
                    return Json(new { CityName = city });
                }
            }
            return Json(false);
        }

        [Route("/viewaddress")]
        [HttpGet]
        public IActionResult GetAddress(string postlcode)
        {
            System.Threading.Thread.Sleep(500);
            var id = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value).SingleOrDefault();
            var address= _helperlandContext.UserAddresses.Where(x => x.UserId ==Int32.Parse(id) && x.PostalCode.Equals(postlcode)).ToList();
            ViewBag.address = address;
            return View();
        }

        [Route("/addaddress")]
        [HttpPost]
        public int AddAddress(ServiceRequestModel serviceRequestModel,string userid)
        {
            try
            {
                UserAddress userAddress = new UserAddress()
                {
                    UserId=Int32.Parse(userid),
                    AddressLine1=serviceRequestModel.AddressLine1,
                    AddressLine2=serviceRequestModel.AddressLine2,
                    City=serviceRequestModel.City,
                    State=serviceRequestModel.State,
                    PostalCode=serviceRequestModel.Postalcode,
                    IsDefault=false,
                    IsDeleted=false,
                    Mobile=serviceRequestModel.Mobile,
                    Email=User.Claims.Where(c=>c.Type=="username").Select(c=>c.Value).SingleOrDefault(),
                };
                _helperlandContext.UserAddresses.Add(userAddress);
               
                var returnvalue=_helperlandContext.SaveChanges();

                return returnvalue;
            }
            catch
            {
                return 0;
            }
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsEmailInUse(string email) =>
         _helperlandContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault() == null ? Json(true) : Json($"Email already exist");
    }
}
