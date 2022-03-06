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
using Microsoft.EntityFrameworkCore;

namespace Helperland.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        public HelperlandContext _helperlandContext = null;
        public readonly Email _email = new Email();
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
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                Email = registrationModel.Email,
                Password = passwordHash,
                Mobile = registrationModel.Mobile,
                UserTypeId = 1,
                IsRegisteredUser = false,
                WorksWithPets = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = 1,
                IsApproved = true,
                IsActive = true,
                IsDeleted = false,
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
                    ServiceStartDate = date,
                    ZipCode = serviceRequestModel.Postalcode,
                    ServiceHourlyRate = serviceRequestModel.ServiceHourlyRate,
                    ServiceHours = serviceRequestModel.ServiceHours,
                    ExtraHours = serviceRequestModel.ExtraHours,
                    TotalCost = serviceRequestModel.TotalCost,
                    Comments = serviceRequestModel.Comments,
                    HasPets = serviceRequestModel.HasPets,
                    Status = 1,
                    RecordVersion = Guid.NewGuid(),
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

                UserAddress userAddress = _helperlandContext.UserAddresses.Where(x => x.AddressId == serviceRequestModel.AddressId).FirstOrDefault();
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
                var result = _helperlandContext.SaveChanges();

                var spEmail = _helperlandContext.Users.Where(u => u.ZipCode == serviceRequest.ZipCode && u.UserTypeId == 2).Select(u => u.Email).ToList();

                var email = new EmailModel()
                {
                    To = spEmail,
                    Subject = "New Service Request arise in your area",
                    isHTML = true,
                    Body = "A new Service request arise in your area with service id " + serviceRequest.ServiceId + " Please check your account if you are intrested ",
                };
                bool ismail = _email.sendMail(email);

                return serviceRequest.ServiceId;
            }
            catch
            {
                _helperlandContext.ServiceRequests.Remove(_helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == serviceRequest.ServiceRequestId).FirstOrDefault());
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
            var address = _helperlandContext.UserAddresses.Where(x => x.UserId == Int32.Parse(id) && x.PostalCode.Equals(postlcode)).ToList();
            ViewBag.address = address;
            return View();
        }

        [Route("/addaddress")]
        [HttpPost]
        public int AddAddress(ServiceRequestModel serviceRequestModel, string userid)
        {
            try
            {
                UserAddress userAddress = new UserAddress()
                {
                    UserId = Int32.Parse(userid),
                    AddressLine1 = serviceRequestModel.AddressLine1,
                    AddressLine2 = serviceRequestModel.AddressLine2,
                    City = serviceRequestModel.City,
                    State = serviceRequestModel.State,
                    PostalCode = serviceRequestModel.Postalcode,
                    IsDefault = false,
                    IsDeleted = false,
                    Mobile = serviceRequestModel.Mobile,
                    Email = User.Claims.Where(c => c.Type == "username").Select(c => c.Value).SingleOrDefault(),
                };
                _helperlandContext.UserAddresses.Add(userAddress);

                var returnvalue = _helperlandContext.SaveChanges();

                return returnvalue;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        [Route("/getfavorite")]
        [HttpGet]
        public IActionResult GetFavoriteSP(string userid)
        {
            var favsp = _helperlandContext.FavoriteAndBlockeds.Where(f => f.UserId == Int32.Parse(userid) && f.IsFavorite).Select(f => f.TargetUserId).ToList();

            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsEmailInUse(string email) =>
         _helperlandContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault() == null ? Json(true) : Json($"Email already exist");

        [Route("/customer/Dashboard")]
        public IActionResult Dashboard()
        {
            var userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var results = (from service in _helperlandContext.ServiceRequests
                           join user in _helperlandContext.Users on service.ServiceProviderId equals user.UserId into sp
                           from serviceProvider in sp.DefaultIfEmpty()
                           where service.UserId == userid && (service.Status == 1 || service.Status == 2)
                           select new FetchServiceDetails
                           {
                               ServiceId = service.ServiceId,
                               ServiceStartTime = service.ServiceStartDate,
                               ServiceHours = service.ServiceHours,
                               ServiceProviderId = service.ServiceProviderId,
                               Profile = serviceProvider.UserProfilePicture,
                               FirstName = serviceProvider.FirstName,
                               LastName = serviceProvider.LastName,
                               TotalCost = service.TotalCost
                           }).ToList();


            foreach (var result in results)
            {
            var rating = _helperlandContext.Ratings.Where(s => s.RatingTo == result.ServiceProviderId).ToList();
                if (rating.Count() > 0)
                {
                    result.AverageRating = rating.Average(a => a.Ratings);
                }
            }

            var details = new FetchServiceDetails()
            {
                Details = results
            };

            return View(details);
        }

        [Route("/getServiceDetail")]
        public IActionResult GetServiceDetail(string serviceid, bool isHistory)
        {
            var servicedetail = (from service in _helperlandContext.ServiceRequests join
                                 address in _helperlandContext.ServiceRequestAddresses on service.ServiceRequestId equals address.ServiceRequestId
                                 join user in _helperlandContext.Users on service.ServiceProviderId equals user.UserId into sp
                                 from serviceProvider in sp.DefaultIfEmpty()
                                 where service.ServiceId == Int32.Parse(serviceid)
                                 select new ServiceDetailsModel {
                                     ServiceStartTime = service.ServiceStartDate,
                                     ServiceHours = service.ServiceHours,
                                     ServiceId = service.ServiceId,
                                     TotalCost = service.TotalCost,
                                     AddressLine1 = address.AddressLine1,
                                     AddressLine2 = address.AddressLine2,
                                     Mobile = address.Mobile,
                                     Email = address.Email,
                                     ServiceProviderId = service.ServiceProviderId,
                                     FirstNamme = serviceProvider.FirstName,
                                     LastName = serviceProvider.LastName,
                                     Profile = serviceProvider.UserProfilePicture,
                                     Comments = service.Comments
                                 }).FirstOrDefault();

            var extra = (from service in _helperlandContext.ServiceRequests
                         join extraservice in _helperlandContext.ServiceRequestExtras on service.ServiceRequestId equals extraservice.ServiceRequestId
                         where service.ServiceId == Int32.Parse(serviceid)
                         select new { extraservice.ServiceExtraId }).ToList();

            if (servicedetail.ServiceProviderId != null)
            {
                servicedetail.TotalCleaning = _helperlandContext.ServiceRequests.Where(s => s.ServiceProviderId == servicedetail.ServiceProviderId && s.Status == 3).Count();

                servicedetail.AverageRating = _helperlandContext.Ratings.Where(s => s.RatingTo == servicedetail.ServiceProviderId).ToList().Average(r => r.Ratings);
            }

            foreach (var e in extra)
            {
                switch (e.ServiceExtraId)
                {
                    case 1:
                        servicedetail.extra.Add("Inside Cabinet");
                        break;
                    case 2:
                        servicedetail.extra.Add("Inside Fridge");
                        break;
                    case 3:
                        servicedetail.extra.Add("Inside Oven");
                        break;
                    case 4:
                        servicedetail.extra.Add("Laundry wash & dry");
                        break;
                    case 5:
                        servicedetail.extra.Add("Interior Windows");
                        break;
                }
            }
            ViewBag.isHistory = isHistory;
            return View(servicedetail);
        }

        [Route("/reschedule")]
        [HttpPost]
        public JsonResult Rechedule(string newServiceDate, string serviceTime, string rescheduleServiceId)
        {
            DateTime updatedTime = DateTime.Parse(newServiceDate);
            updatedTime = updatedTime.AddHours(Double.Parse(serviceTime));
            var servicerequest = _helperlandContext.ServiceRequests.Where(s => s.ServiceId == Int32.Parse(rescheduleServiceId)).FirstOrDefault();
            if (servicerequest != null)
            {
                var updatedEnd = updatedTime.AddHours(servicerequest.ServiceHours).AddMinutes(30);
                if (updatedTime.CompareTo(servicerequest.ServiceStartDate) == 0)
                {
                    return Json(new { Result = false, error = "Please select different date as you selected already schedueled date" });
                }
                else if (servicerequest.ServiceProviderId != null)
                {
                    var services = _helperlandContext.ServiceRequests.Where(s => s.ServiceProviderId == servicerequest.ServiceProviderId && (s.Status == 1 || s.Status == 2) && s.ServiceId != Int32.Parse(rescheduleServiceId)).ToList();
                    foreach (var service in services)
                    {
                        var serviceStart = service.ServiceStartDate;
                        var serviceEnd = service.ServiceStartDate.AddHours(service.ServiceHours).AddMinutes(30);
                        if ((updatedEnd.CompareTo(serviceStart) > 0 && updatedEnd.CompareTo(serviceEnd) <= 0) || (updatedTime.CompareTo(serviceStart) >= 0 && updatedTime.CompareTo(serviceEnd) < 0) || ((updatedTime.CompareTo(serviceStart) >= 0 && updatedEnd.CompareTo(serviceEnd) < 0)))
                        {
                            return Json(new { Result = false, error = "Another service request has been assigned to the service provider on " + serviceStart.ToString("dd/MM/yyyy") +
                            " from " + serviceStart.ToString("HH/mm") + " to " + serviceEnd.ToString("HH/mm") + ". Either choose another date or pick up a different time slot." });
                        }
                    }
                }
                servicerequest.ServiceStartDate = updatedTime;
                servicerequest.ModifiedDate = DateTime.Now;
                servicerequest.ModifiedBy = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                _helperlandContext.ServiceRequests.Attach(servicerequest);
                _helperlandContext.SaveChanges();
                return Json(new { Result = true });
            }
            else
            {
                return Json(new { Result = false, error = "service request does not exists" });
            }
        }

        [Route("/canclerequest")]
        [HttpPost]
        public JsonResult CancleRequest(string cancleReason, string cancelServiceId)
        {
            var servicerequest = _helperlandContext.ServiceRequests.Where(s => s.ServiceId == Int32.Parse(cancelServiceId)).FirstOrDefault(); ;
            if (servicerequest != null)
            {
                servicerequest.ModifiedDate = DateTime.Now;
                servicerequest.ModifiedBy = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                servicerequest.Status = 4;
                servicerequest.Comments = cancleReason;
                _helperlandContext.ServiceRequests.Attach(servicerequest);
                _helperlandContext.SaveChanges();
                return Json(new { result = true });
            }
            else
            {
                return Json(new { Result = false, error = "service request does not exists" });
            }
        }

        [Route("/servicehistory")]
        [HttpGet]
        public IActionResult ServiceHistory()
        {
            var userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var results = (from service in _helperlandContext.ServiceRequests
                           join user in _helperlandContext.Users on service.ServiceProviderId equals user.UserId into sp
                           from serviceProvider in sp.DefaultIfEmpty()
                           where service.UserId == userid && (service.Status == 3 || service.Status == 4)
                           select new FetchServiceDetails
                           {
                               ServiceId = service.ServiceId,
                               ServiceStartTime = service.ServiceStartDate,
                               ServiceHours = service.ServiceHours,
                               ServiceProviderId = service.ServiceProviderId,
                               Profile = serviceProvider.UserProfilePicture,
                               FirstName = serviceProvider.FirstName,
                               LastName = serviceProvider.LastName,
                               TotalCost = service.TotalCost,
                               Status = service.Status
                           }).ToList();

            foreach (var result in results)
            {
                var rating = _helperlandContext.Ratings.Where(s => s.RatingTo == result.ServiceProviderId).ToList();
                if (rating.Count() > 0)
                {
                    result.AverageRating = rating.Average(a => a.Ratings);
                }
            }

            var details = new FetchServiceDetails() {
                Details = results
            };

            return View(details);
        }

        [Route("/servicerating")]
        [HttpGet]
        public JsonResult ServiceRating(int spid,int serviceid)
        {
            var rating = (from service in _helperlandContext.ServiceRequests
                          join rate in _helperlandContext.Ratings on service.ServiceRequestId equals rate.ServiceRequestId
                          where service.ServiceId == serviceid
                          select new { OnTimeArrival = rate.OnTimeArrival, Friendly = rate.Friendly, QualityOfService = rate.QualityOfService }
                          ).FirstOrDefault();

            var sp = _helperlandContext.Users.Where(u=>u.UserId== spid).FirstOrDefault();
            var sprating = _helperlandContext.Ratings.Where(s => s.RatingTo == spid).ToList();
            decimal avgRating = 0;
            if (sprating.Count() > 0)
            {
                avgRating = sprating.Average(a => a.Ratings);
            }

            if (rating == null)
            {
                var result =new  { FirstName = sp.FirstName, LastName = sp.LastName, Profile = sp.UserProfilePicture ,AvgRating= avgRating ,AlreadyRated=false};
                return Json(result);
            }
            else
            {
                var result =new  { FirstName = sp.FirstName, LastName = sp.LastName, Profile = sp.UserProfilePicture ,AvgRating= avgRating ,AlreadyRated=true, OnTimeArrival = rating.OnTimeArrival, Friendly = rating.Friendly, QualityOfService = rating.QualityOfService };
                return Json(result);
            }
        }

        [Route("/servicerating")]
        [HttpPost]
        public JsonResult ServiceRating(FetchServiceDetails serviceRating)
        {
            try
            {
                var sp = _helperlandContext.ServiceRequests.Where(u => u.ServiceId == serviceRating.ServiceId).FirstOrDefault();
                var rating = new Rating()
                {
                    ServiceRequestId= sp.ServiceRequestId,
                    RatingFrom= Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                    RatingTo=(int)serviceRating.ServiceProviderId,
                    Ratings= serviceRating.AverageRating,
                    Comments= serviceRating.Comment,
                    RatingDate=DateTime.Now,
                    OnTimeArrival= serviceRating.OnTimeArrival,
                    Friendly= serviceRating.Friendly,
                    QualityOfService= serviceRating.QualityOfService
                };
                _helperlandContext.Ratings.Add(rating);
                _helperlandContext.SaveChanges();
                return Json(new { Result=true });
            }
            catch (Exception e)
            {
                return Json(new { Result = false, Error = e });
            }
        }

        [Route("/mysetting")]
        [HttpGet]
        public IActionResult MySetting()
        {
            int userid = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _helperlandContext.Users.Where(user => user.UserId == userid).FirstOrDefault();
            var myaccount = new MyAccountModel()
            {
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email=user.Email,
                Mobile=user.Mobile,
                LanguageId=user.LanguageId
            };
            var dob = user.DateOfBirth;
            if (dob != null)
            {
                myaccount.Day = dob.Value.Day;
                myaccount.Month = dob.Value.Month;
                myaccount.Year = dob.Value.Year;
            }
            return View(myaccount);
        }

        [Route("/mydetail")]
        [HttpPost]
        public JsonResult MyDetails(MyAccountModel myAccountModel)
        {
            try
            {
                int userid = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var user = _helperlandContext.Users.Where(user => user.UserId == userid).FirstOrDefault();
                user.FirstName = myAccountModel.FirstName;
                user.LastName = myAccountModel.LastName;
                user.Mobile = myAccountModel.Mobile;
                user.LanguageId = myAccountModel.LanguageId;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = user.UserId;
                user.DateOfBirth = new DateTime(myAccountModel.Year, myAccountModel.Month, myAccountModel.Day, 0, 0, 0, 0); ;
                _helperlandContext.Users.Attach(user);
                _helperlandContext.SaveChanges();
            
                return Json(new { Result = true });
            }
            catch
            {
                return Json(new { Result = false });

            }
        }
        [Route("/customeraddress")]
        public IActionResult CustomerAddress()
        {
            var userid =Int32.Parse( User.FindFirstValue(ClaimTypes.NameIdentifier));
            var address = _helperlandContext.UserAddresses.Where(a => a.UserId == userid).ToList();
            ViewBag.address = address;
            return View();
        }

        [Route("/customeraddress")]
        [HttpPost]
        public JsonResult CustomerAddress(MyAccountModel addressModel , string todo)
        {
            var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (todo == "edit")
            {
                if(addressModel != null)
                {
                    var address = _helperlandContext.UserAddresses.Where(add => add.AddressId == addressModel.address.AddressId).FirstOrDefault();
                    address.AddressLine1 = addressModel.address.AddressLine1;
                    address.AddressLine2 = addressModel.address.AddressLine2;
                    address.City = addressModel.address.City;
                    address.PostalCode = addressModel.address.PostalCode;
                    address.Mobile = addressModel.address.Mobile;

                    _helperlandContext.UserAddresses.Attach(address);
                    _helperlandContext.SaveChanges();

                    return Json(new { Result = true });
                }

            }else if (todo == "new")
            {
                var address = new UserAddress();
                address.UserId = userid;
                address.AddressLine1 = addressModel.address.AddressLine1;
                address.AddressLine2 = addressModel.address.AddressLine2;
                address.City = addressModel.address.City;
                address.PostalCode = addressModel.address.PostalCode;
                address.Mobile = addressModel.address.Mobile;

                _helperlandContext.UserAddresses.Add(address);
                _helperlandContext.SaveChanges();

                return Json(new { Result = true });
            }
            return Json(new { Result = false ,Error="Internal Server Error"});
        }

        [Route("/deletecustomeraddress")]
        [HttpPost]
        public JsonResult DeleteAddress(int addressid)
        {
            var address = _helperlandContext.UserAddresses.Where(add => add.AddressId == addressid).FirstOrDefault();
            _helperlandContext.UserAddresses.Remove(address);
            _helperlandContext.SaveChanges();
            return Json(new { result=true});
        }

        [Route("/findCity")]
        [HttpPost]
        public JsonResult CityName(string postalcode)
        {
            if (postalcode != null)
            {
                var city = (
                            from z in _helperlandContext.Zipcodes
                            join c in _helperlandContext.Cities
                            on z.CityId equals c.Id
                            where z.ZipcodeValue == postalcode
                            select c.CityName
                        ).FirstOrDefault();
                if (city != null)
                {
                    return Json(new { City = city });
                }
                else
                {
                    return Json(false);
                }
            }
                return Json(false);
        }

        [Route("/changepassword")]
        [HttpPost]
        public JsonResult ChangePassword(MyAccountModel myAccountModel)
        {
            try
            {
                var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var user = _helperlandContext.Users.Where(u => u.UserId == userid).FirstOrDefault();
                if (user != null)
                {
                    var isVerified = Crypto.VerifyHashedPassword(user.Password,myAccountModel.OldPassword);
                    if (!isVerified)
                    {
                        return Json(new { Result = false ,Error="Old Password is Incorrect!"});
                    }
                    user.Password = Crypto.HashPassword(myAccountModel.NewPassword);
                    user.ModifiedDate = DateTime.Now;
                    user.ModifiedBy = userid;
                    _helperlandContext.Users.Attach(user);
                    _helperlandContext.SaveChanges();
                    return Json(new { Result = true });
                }
                return Json(new { Result = false ,Error="Internal Server Error"});
            }
            catch
            {
                return Json(new { Result = false ,Error= "Internal Server Error" });
            }
        }
    }
}
