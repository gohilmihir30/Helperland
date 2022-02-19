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
    public class CustomerController : Controller
    {
        public HelperlandContext _helperlandContext = null;

        public CustomerController(HelperlandContext helperlandContext)
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

        [Route("/book-service")]
        public IActionResult BookService()
        {
            return View();
        }
        
        [Route("/book-service")]
        [HttpPost]
        public int BookService(ServiceRequestModel serviceRequestModel)
        {
            int _random = new Random().Next(1000,9999);
            var isExist= _helperlandContext.ServiceRequests.Where(x => x.ServiceId == _random).FirstOrDefault();
            while (isExist != null)
            {
                _random= new Random().Next(1000, 9999);
                isExist = _helperlandContext.ServiceRequests.Where(x => x.ServiceId == _random).FirstOrDefault();
            }

            var serviceRequest = new ServiceRequest()
            {
                UserId=1,
                ServiceId = _random,
                ServiceStartDate=Convert.ToDateTime(serviceRequestModel.ServiceStartDate),
                ZipCode=serviceRequestModel.Postalcode,
                ServiceHourlyRate=serviceRequestModel.ServiceHourlyRate,
                ServiceHours=serviceRequestModel.ServiceHours,
                ExtraHours=serviceRequestModel.ExtraHours,
                TotalCost=serviceRequestModel.TotalCost,
                Comments=serviceRequestModel.Comments,
                HasPets=serviceRequestModel.HasPets,
                Status=1,
                CreatedDate=DateTime.Now,
                ModifiedDate=DateTime.Now
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
            }if (serviceRequestModel.Fridge)
            {
                var serviceRequestExtra = new ServiceRequestExtra()
                {
                    ServiceRequestId = serviceRequest.ServiceRequestId,
                    ServiceExtraId = 2
                };
                _helperlandContext.ServiceRequestExtras.Add(serviceRequestExtra);
            }if (serviceRequestModel.Oven)
            {
                var serviceRequestExtra = new ServiceRequestExtra()
                {
                    ServiceRequestId = serviceRequest.ServiceRequestId,
                    ServiceExtraId = 3
                };
                _helperlandContext.ServiceRequestExtras.Add(serviceRequestExtra);
            }if (serviceRequestModel.Laundry)
            {
                var serviceRequestExtra = new ServiceRequestExtra()
                {
                    ServiceRequestId = serviceRequest.ServiceRequestId,
                    ServiceExtraId = 4
                };
                _helperlandContext.ServiceRequestExtras.Add(serviceRequestExtra);
            }if (serviceRequestModel.Windows)
            {
                var serviceRequestExtra = new ServiceRequestExtra()
                {
                    ServiceRequestId = serviceRequest.ServiceRequestId,
                    ServiceExtraId = 5
                };
                _helperlandContext.ServiceRequestExtras.Add(serviceRequestExtra);
            }

            UserAddress userAddress= _helperlandContext.UserAddresses.Where(x => x.AddressId == serviceRequestModel.AddressId).FirstOrDefault();
            var serviceRequestAddress = new ServiceRequestAddress()
            {
                ServiceRequestId = serviceRequest.ServiceRequestId,
                AddressLine1= userAddress.AddressLine1,
                AddressLine2= userAddress.AddressLine2,
                City= userAddress.City,
                State= userAddress.State,
                PostalCode= userAddress.PostalCode,
                Mobile= userAddress.Mobile,
                Email=userAddress.Email
            };
            _helperlandContext.ServiceRequestAddresses.Add(serviceRequestAddress);

            _helperlandContext.ServiceRequests.Attach(serviceRequest);
            _helperlandContext.SaveChanges();
            
            return serviceRequest.ServiceId;
        }


        [Route("/check-availability")]
        [HttpPost]
        public Boolean CheckAvailability(string postalCode)
        {
            var isExists = _helperlandContext.Users.Where(x => x.ZipCode.Equals(postalCode)).ToList();
            if(isExists.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Route("/viewaddress")]
        [HttpGet]
        public IActionResult GetAddress(string userid)
        {
            System.Threading.Thread.Sleep(500);
            var address= _helperlandContext.UserAddresses.Where(x => x.UserId == Int32.Parse(userid)).ToList();
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
                    Email=null,
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
