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
            var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var serviceRequest = new ServiceRequest();
            int serviceRequestId = 0;
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
                    ModifiedBy = userid,
                    RecordVersion = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                if (serviceRequestModel.FavoriteSP != 0)
                {
                    serviceRequest.Status = 2;
                    serviceRequest.ServiceProviderId = serviceRequestModel.FavoriteSP;
                    serviceRequest.SpacceptedDate = DateTime.Now;
                }

                _helperlandContext.ServiceRequests.Add(serviceRequest);
                _helperlandContext.SaveChanges();
                serviceRequestId = serviceRequest.ServiceRequestId;

                if (serviceRequestModel.Cabinet)
                {
                    var serviceRequestExtra = new ServiceRequestExtra()
                    {
                        ServiceRequestId = serviceRequest.ServiceRequestId,
                        ServiceExtraId = 1
                    };
                    serviceRequest.ServiceRequestExtras.Add(serviceRequestExtra);
                }
                if (serviceRequestModel.Fridge)
                {
                    var serviceRequestExtra = new ServiceRequestExtra()
                    {
                        ServiceRequestId = serviceRequest.ServiceRequestId,
                        ServiceExtraId = 2
                    };
                    serviceRequest.ServiceRequestExtras.Add(serviceRequestExtra);
                }
                if (serviceRequestModel.Oven)
                {
                    var serviceRequestExtra = new ServiceRequestExtra()
                    {
                        ServiceRequestId = serviceRequest.ServiceRequestId,
                        ServiceExtraId = 3
                    };
                    serviceRequest.ServiceRequestExtras.Add(serviceRequestExtra);
                }
                if (serviceRequestModel.Laundry)
                {
                    var serviceRequestExtra = new ServiceRequestExtra()
                    {
                        ServiceRequestId = serviceRequest.ServiceRequestId,
                        ServiceExtraId = 4
                    };
                    serviceRequest.ServiceRequestExtras.Add(serviceRequestExtra);
                }
                if (serviceRequestModel.Windows)
                {
                    var serviceRequestExtra = new ServiceRequestExtra()
                    {
                        ServiceRequestId = serviceRequest.ServiceRequestId,
                        ServiceExtraId = 5
                    };
                    serviceRequest.ServiceRequestExtras.Add(serviceRequestExtra);
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
                serviceRequest.ServiceRequestAddresses.Add(serviceRequestAddress);
                _helperlandContext.ServiceRequests.Attach(serviceRequest);
                var result = _helperlandContext.SaveChanges();

                return serviceRequest.ServiceId;
            }
            catch
            {
                var extra = serviceRequest.ServiceRequestExtras.Where(s => s.ServiceRequestId == serviceRequestId).ToList();
                foreach (var e in extra)
                {
                    serviceRequest.ServiceRequestExtras.Remove(e);
                }
                var add = serviceRequest.ServiceRequestAddresses.Where(s => s.ServiceRequestId == serviceRequest.ServiceRequestId).ToList();
                foreach (var a in add)
                {
                    serviceRequest.ServiceRequestAddresses.Remove(a);
                }
                var tempServiceRequest = _helperlandContext.ServiceRequests.Where(s => s.ServiceRequestId == serviceRequestId).FirstOrDefault();
                if(tempServiceRequest != null)
                {
                    _helperlandContext.ServiceRequests.Remove(tempServiceRequest);
                    _helperlandContext.SaveChanges();
                }
                return 0;
            }
        }

        [Route("/check-availability")]
        [HttpPost]
        public JsonResult CheckAvailability(string postalCode)
        {
            var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (postalCode != null)
            {
                var isAvailable = (from user in _helperlandContext.Users
                                   where !((from fav1 in _helperlandContext.FavoriteAndBlockeds where fav1.UserId == userid && fav1.IsBlocked == true select (fav1.TargetUserId)).Union(from fav2 in _helperlandContext.FavoriteAndBlockeds where fav2.TargetUserId == userid && fav2.IsBlocked == true select (fav2.UserId))).Contains(user.UserId) && user.UserTypeId==2 && user.ZipCode==postalCode select (user.UserId.ToString())).ToList();
                if (isAvailable.Count()>0)
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

        [Route("/getfavoritesp")]
        [HttpGet]
        public IActionResult GetFavoriteSP()
        {
            var userid =Int32.Parse( User.FindFirstValue(ClaimTypes.NameIdentifier));

            var favsp = (from fav in _helperlandContext.FavoriteAndBlockeds 
                         join user in _helperlandContext.Users on fav.TargetUserId equals user.UserId
                         where fav.UserId==userid && fav.IsFavorite==true
                         select new FavoriteAndBlockeModel{
                            FirstName=user.FirstName,
                            LastName=user.LastName,
                            Profile=user.UserProfilePicture,
                            TargetUserId=fav.TargetUserId
                         }).ToList();

            
            return View(new FavoriteAndBlockeModel() { 
                blocked= favsp
            });
        }

        [AllowAnonymous]
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
                var updatedEnd = updatedTime.AddHours(servicerequest.ServiceHours).AddHours(1);
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
                        var serviceEnd = service.ServiceStartDate.AddHours(service.ServiceHours).AddHours(1);
                        if ((updatedEnd.CompareTo(serviceStart) > 0 && updatedEnd.CompareTo(serviceEnd) <= 0) || (updatedTime.CompareTo(serviceStart) >= 0 && updatedTime.CompareTo(serviceEnd) < 0) || ((serviceStart.CompareTo(updatedTime) >= 0 && serviceEnd.CompareTo(updatedEnd) < 0)))
                        {
                            return Json(new { Result = false, error = "Another service request has been assigned to the service provider on " + serviceStart.ToString("dd/MM/yyyy") +
                            " from " + serviceStart.ToString("HH/mm") + " to " + serviceEnd.AddHours(-1).ToString("HH/mm") + ". Either choose another date or pick up a different time slot." });
                        }
                    }
                }
                servicerequest.ServiceStartDate = updatedTime;
                servicerequest.ModifiedDate = DateTime.Now;
                servicerequest.ModifiedBy = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                _helperlandContext.ServiceRequests.Attach(servicerequest);
                _helperlandContext.SaveChanges();

                if (servicerequest.ServiceProviderId != null)
                {
                    var spEmail = _helperlandContext.Users.Where(u => u.UserId == servicerequest.ServiceProviderId).Select(u => u.Email).FirstOrDefault();
                    var email = new EmailModel()
                    {
                        To = new List<string> { spEmail },
                        Subject = "Regarding Rechedule of service request",
                        isHTML = true,
                        Body = "Service Request "+servicerequest.ServiceId+" has been rescheduled by customer. New date and time are "+servicerequest.ServiceStartDate,
                    };
                    bool ismail = _email.sendMail(email);
                }

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

                if(servicerequest.ServiceProviderId != null)
                {
                    var spEmail = _helperlandContext.Users.Where(u => u.UserId == servicerequest.ServiceProviderId).Select(u => u.Email).FirstOrDefault();
                    var email = new EmailModel()
                    {
                        To = new List<string> { spEmail },
                        Subject = "Regarding Service Request cancellation",
                        isHTML = true,
                        Body = "Service Request "+servicerequest.ServiceId +" has been cancelled by customer",
                    };
                    bool ismail = _email.sendMail(email);
                }
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
                user.DateOfBirth = new DateTime((int)myAccountModel.Year, (int)myAccountModel.Month, (int)myAccountModel.Day, 0, 0, 0, 0); ;
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


        [Route("/favoriteProvider")]
        public IActionResult FavoriteProvider()
        {
            var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (userid != 0)
            {
                var sp = (from service in _helperlandContext.ServiceRequests
                          join
                            user in _helperlandContext.Users on service.ServiceProviderId equals user.UserId
                          join
                            rating in _helperlandContext.Ratings on service.ServiceProviderId equals rating.RatingTo into rating_join
                          from rating in rating_join.DefaultIfEmpty()
                          join fab in _helperlandContext.FavoriteAndBlockeds on new { UserId = service.UserId.ToString(), TragetId = service.ServiceProviderId.ToString() } equals new { UserId = fab.UserId.ToString(), TragetId = fab.TargetUserId.ToString() } into fab_join
                          from fab in fab_join.DefaultIfEmpty()
                          where service.UserId == userid && service.Status == 3
                          group new { user, service, rating } by new { service.ServiceProviderId, user.FirstName, user.LastName, user.UserProfilePicture, fab.UserId, fab.TargetUserId, fab.IsBlocked, fab.IsFavorite } into serviceprovider
                          select new FavoriteAndBlockeModel
                          {
                              UserId = serviceprovider.Key.UserId,
                              TargetUserId = serviceprovider.Key.TargetUserId,
                              isBlocked = serviceprovider.Key.IsBlocked,
                              isFavorite = serviceprovider.Key.IsFavorite,
                              FirstName = serviceprovider.Key.FirstName,
                              LastName = serviceprovider.Key.LastName,
                              SPId = serviceprovider.Key.ServiceProviderId,
                              Profile = serviceprovider.Key.UserProfilePicture,
                              Rating = serviceprovider.Where(a => a.rating.RatingTo == serviceprovider.Key.ServiceProviderId).Average(a => a.rating.Ratings)
                          }).ToList();

                foreach(var service in sp.ToList())
                {
                    var blockcust = _helperlandContext.FavoriteAndBlockeds.Where(f => f.UserId == service.SPId && f.TargetUserId == userid && f.IsBlocked == true).FirstOrDefault();
                    service.CleaningCount = _helperlandContext.ServiceRequests.Where(s => s.ServiceProviderId == service.SPId && s.Status==3).Select(s => s.ServiceRequestId).Distinct().Count();
                    if(blockcust !=null)
                    {
                        sp.Remove(service);
                    }
                }
                var favsp = new FavoriteAndBlockeModel()
                {
                    blocked = sp
                };
                return View(favsp);
            }
            return Redirect("/?modalRequest=true");
        }
    }
}
