using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models.ViewModels;
using Helperland.Models.Data;
using System.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Helperland.Controllers
{
    [Authorize(Roles = "ServiceProvider")]
    public class ServiceProviderController : Controller
    {
        public readonly HelperlandContext _helperlandContext = null;
        public ServiceProviderController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }

        [Route("/sp-signup")]
        [AllowAnonymous]
        public IActionResult SPSignup()
        {
            return View();
        }

        [Route("/sp-signup")]
        [AllowAnonymous]
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

        [Route("/sp/Dashboard")]
        public IActionResult Dashboard()
        {
            var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var services = (from service in _helperlandContext.ServiceRequests
                            join
                            user in _helperlandContext.Users on service.UserId equals user.UserId
                            join
                            serviceaddress in _helperlandContext.ServiceRequestAddresses on service.ServiceRequestId equals serviceaddress.ServiceRequestId
                            where service.Status == 1
                            select new FetchServiceDetails
                            {
                                UserId=service.UserId,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                ServiceId = service.ServiceId,
                                ServiceStartTime = service.ServiceStartDate,
                                ServiceHours = service.ServiceHours,
                                Address1 = serviceaddress.AddressLine1,
                                Address2 = serviceaddress.AddressLine2,
                                PostalCode = serviceaddress.PostalCode,
                                City = serviceaddress.City,
                                RecordVersion = service.RecordVersion,
                                TotalCost = service.TotalCost
                            }).ToList();

            var blockService = _helperlandContext.FavoriteAndBlockeds.Where(s => (s.UserId == userid || s.TargetUserId==userid ) && s.IsBlocked == true).ToList();
            //var details = services;
            foreach(var s in services.ToList())
            {
                foreach(var b in blockService)
                {
                    if ((b.UserId == userid && b.TargetUserId == s.UserId) || (b.TargetUserId == userid && b.UserId == s.UserId))
                    {
                        services.Remove(s);
                    }
                }
            }
            var serviceRequest = new FetchServiceDetails()
            {
                Details = services
            };
            return View(serviceRequest);
        }

        [Route("/sp/getServiceDetail")]
        [HttpGet]
        public IActionResult GetServicesDetails(int serviceid,int page)
        {
            var servicedetails = (from service in _helperlandContext.ServiceRequests
                                  join
                                    serviceadd in _helperlandContext.ServiceRequestAddresses on service.ServiceRequestId equals serviceadd.ServiceRequestId
                                  join
                                    user in _helperlandContext.Users on service.UserId equals user.UserId
                                  where service.ServiceId == serviceid
                                  select new ServiceDetailsModel
                                  {
                                      FirstNamme = user.FirstName,
                                      LastName = user.LastName,
                                      AddressLine1 = serviceadd.AddressLine1,
                                      AddressLine2 = serviceadd.AddressLine2,
                                      PostalCode = serviceadd.PostalCode,
                                      City = serviceadd.City,
                                      ServiceStartTime = service.ServiceStartDate,
                                      ServiceHours = service.ServiceHours,
                                      ServiceId = service.ServiceId,
                                      TotalCost = service.TotalCost,
                                      RecordVersion = service.RecordVersion,
                                      Comments = service.Comments
                                  }).FirstOrDefault();

            var extra = (from service in _helperlandContext.ServiceRequests
                         join extraservice in _helperlandContext.ServiceRequestExtras on service.ServiceRequestId equals extraservice.ServiceRequestId
                         where service.ServiceId == serviceid
                         select new { extraservice.ServiceExtraId }).ToList();

            foreach (var e in extra)
            {
                switch (e.ServiceExtraId)
                {
                    case 1:
                        servicedetails.extra.Add("Inside Cabinet");
                        break;
                    case 2:
                        servicedetails.extra.Add("Inside Fridge");
                        break;
                    case 3:
                        servicedetails.extra.Add("Inside Oven");
                        break;
                    case 4:
                        servicedetails.extra.Add("Laundry wash & dry");
                        break;
                    case 5:
                        servicedetails.extra.Add("Interior Windows");
                        break;
                }
            }
            ViewBag.page = page;
            return View(servicedetails);
        }

        [Route("/acceptservice")]
        [HttpPost]
        public JsonResult AcceptService(int serviceid, string record)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var service = _helperlandContext.ServiceRequests.Where(s => s.ServiceId == serviceid).FirstOrDefault();
                var servicestart = service.ServiceStartDate;
                var serviceend = service.ServiceStartDate.AddHours(service.ServiceHours).AddHours(1);
                if (service.RecordVersion.ToString().Equals(record) && service.ServiceProviderId == null)
                {
                    var acceptedservices = _helperlandContext.ServiceRequests.Where(s => s.ServiceProviderId == userid && s.Status == 2).ToList();
                    foreach (var acceptedservice in acceptedservices)
                    {
                        var acceptedstart = acceptedservice.ServiceStartDate;
                        var acceptedend = acceptedservice.ServiceStartDate.AddHours(acceptedservice.ServiceHours).AddHours(1);

                        if ((serviceend.CompareTo(acceptedstart) > 0 && serviceend.CompareTo(acceptedend) <= 0) || (servicestart.CompareTo(acceptedstart) >= 0 && servicestart.CompareTo(acceptedend) < 0) || ((servicestart.CompareTo(acceptedstart) >= 0 && serviceend.CompareTo(acceptedend) < 0)))
                        {
                            return Json(new { Result = false, Error = "Another service request " + acceptedservice.ServiceId + " has already been assigned which has time overlap with this service request. You can’t pick this one!" });
                        }
                    }
                    service.ServiceProviderId = userid;
                    service.RecordVersion = Guid.NewGuid();
                    service.Status = 2;
                    service.SpacceptedDate = DateTime.Now;
                    service.ModifiedBy = userid;
                    service.ModifiedDate = DateTime.Now;

                    _helperlandContext.ServiceRequests.Attach(service);
                    _helperlandContext.SaveChanges();
                    return Json(new { Result = true });
                }
                return Json(new { Result = false, Error = "This service request is no more available. It has been assigned to another provider." });
            }
            else
            {
                Redirect("/?modalRequest=true");
                return Json(new { Result = false });
            }
        }

        [Route("/conflictservice")]
        [HttpPost]
        public JsonResult ConflictService(int serviceid)
        {
            var userrid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (User.Identity.IsAuthenticated)
            {
                var currentservice = _helperlandContext.ServiceRequests.Where(s => s.ServiceId == serviceid).FirstOrDefault();
                var starttime = currentservice.ServiceStartDate;
                var endtime = currentservice.ServiceStartDate.AddHours(currentservice.ServiceHours + 1);
                var today = DateTime.Now.ToLongDateString();

                var otherservices = _helperlandContext.ServiceRequests.Where(s => s.Status == 2 && s.ServiceProviderId == userrid).ToList();

                foreach (var ser in otherservices)
                {
                    var otherstarttime = ser.ServiceStartDate;
                    var otherendtime = ser.ServiceStartDate.AddHours(ser.ServiceHours + 1);

                    if ((endtime.CompareTo(otherstarttime) > 0 && endtime.CompareTo(otherendtime) <= 0) || (starttime.CompareTo(otherstarttime) >= 0 && starttime.CompareTo(otherendtime) < 0) || ((starttime.CompareTo(otherstarttime) >= 0 && endtime.CompareTo(otherendtime) < 0)))
                    {
                        return Json(new { Result = true, Serviceid = ser.ServiceId, ServicestartDate = ser.ServiceStartDate.ToString("dd/MM/yyyy"), servicestarttime = otherstarttime.ToString("HH/mm"), serviceendtime = otherendtime.AddHours(-1).ToString("HH/mm") });
                    }
                }
                return Json(new { Result = false, Error = "No service request conflict with this service" });
            }
            return Json(new { Result = false, Error = "user is not authenticated" });
        }

        [Route("/sp/upcomingservices")]
        [HttpGet]
        public IActionResult UpcomingService()
        {
            var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var upcomingservice = (from service in _helperlandContext.ServiceRequests
                                   join
                                   user in _helperlandContext.Users on service.UserId equals user.UserId
                                   join
                                   serviceaddress in _helperlandContext.ServiceRequestAddresses on service.ServiceRequestId equals  serviceaddress.ServiceRequestId
                                   where service.Status == 2 && service.ServiceProviderId==userid
                                   select new FetchServiceDetails
                                   {
                                       FirstName = user.FirstName,
                                       LastName = user.LastName,
                                       ServiceId = service.ServiceId,
                                       ServiceStartTime = service.ServiceStartDate,
                                       ServiceHours = service.ServiceHours,
                                       Address1 = serviceaddress.AddressLine1,
                                       Address2 = serviceaddress.AddressLine2,
                                       PostalCode = serviceaddress.PostalCode,
                                       City = serviceaddress.City,
                                       TotalCost = service.TotalCost
                                   }).ToList();
            var details = new FetchServiceDetails()
            {
                Details = upcomingservice
            };
            return View(details);
        }

        [Route("/cancelrequest")]
        [HttpPost]
        public JsonResult CancelRequest(int serviceid)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid= Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var servicerequest = _helperlandContext.ServiceRequests.Where(s => s.ServiceId == serviceid && s.ServiceProviderId==userid).FirstOrDefault(); 
                if (servicerequest != null)
                {
                    servicerequest.ServiceProviderId = null;
                    servicerequest.ModifiedDate = DateTime.Now;
                    servicerequest.ModifiedBy = userid;
                    servicerequest.Status = 1;
                    servicerequest.SpacceptedDate = null;
                    _helperlandContext.ServiceRequests.Attach(servicerequest);
                    _helperlandContext.SaveChanges();
                    return Json(new { result = true , redirect = false }); ;
                }
                else
                {
                    return Json(new { Result = false, redirect = false,  error = "Either service request does not exists or you are not the right SP to cancle the service" });
                }
            }
            return Json(new { Result = false ,returnUrl= "/?modalRequest=true",redirect=true });
        }

        [Route("/completeservice")]
        [HttpPost]
        public JsonResult CompleteService(int serviceid)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid= Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var servicerequest = _helperlandContext.ServiceRequests.Where(s => s.ServiceId == serviceid && s.ServiceProviderId==userid).FirstOrDefault(); 
                if (servicerequest != null)
                {
                    servicerequest.ModifiedDate = DateTime.Now;
                    servicerequest.ModifiedBy = userid;
                    servicerequest.Status = 3;
                    _helperlandContext.ServiceRequests.Attach(servicerequest);
                    _helperlandContext.SaveChanges();
                    return Json(new { result = true, redirect = false }); ;
                }
                else
                {
                    return Json(new { Result = false, redirect = false, error = "Either service request does not exists or you are not the right SP to completeacc the service" });
                }
            }
            return Json(new { Result = false ,returnUrl= "/?modalRequest=true",redirect=true });
        }

        [Route("/sp/servicehistory")]
        public IActionResult ServiceHistory()
        {
            var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var servicehistory = (from service in _helperlandContext.ServiceRequests
                                   join
                                   user in _helperlandContext.Users on service.UserId equals user.UserId
                                   join
                                   serviceaddress in _helperlandContext.ServiceRequestAddresses on service.ServiceRequestId equals serviceaddress.ServiceRequestId
                                   where service.Status == 3 && service.ServiceProviderId == userid
                                   select new FetchServiceDetails
                                   {
                                       FirstName = user.FirstName,
                                       LastName = user.LastName,
                                       ServiceId = service.ServiceId,
                                       ServiceStartTime = service.ServiceStartDate,
                                       ServiceHours = service.ServiceHours,
                                       Address1 = serviceaddress.AddressLine1,
                                       Address2 = serviceaddress.AddressLine2,
                                       PostalCode = serviceaddress.PostalCode,
                                       City = serviceaddress.City,
                                   }).ToList();
            var details = new FetchServiceDetails()
            {
                Details = servicehistory
            };
            return View(details);
        }

        [Route("/myrating")]
        public IActionResult MyRating()
        {
            var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var ratings = (from service in _helperlandContext.ServiceRequests join 
                           user in _helperlandContext.Users on service.UserId equals user.UserId join
                           rate in _helperlandContext.Ratings on service.ServiceRequestId equals rate.ServiceRequestId
                           where service.ServiceProviderId == userid
                           select new SPRatingModel{ 
                           FirstName=user.FirstName,
                           LastName=user.LastName,
                           ServiceId=service.ServiceId,
                           ServiceStartDate=service.ServiceStartDate,
                           ServiceHours=service.ServiceHours,
                           Rating=rate.Ratings,
                           Comments=rate.Comments
                           }).ToList();
            var rating = new SPRatingModel()
            {
                spRatingModel = ratings
            };
            return View(rating);
        }

        [Route("/blockcustomer")]
        public IActionResult BlockCustomer()
        {
            var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var blockcustomer = (from ServiceRequest in _helperlandContext.ServiceRequests
                                 join User in _helperlandContext.Users on ServiceRequest.UserId equals User.UserId
                                 join FavoriteAndBlocked in _helperlandContext.FavoriteAndBlockeds
                                       on new { ServiceProviderId = ServiceRequest.ServiceProviderId.ToString(),  UserId=ServiceRequest.UserId.ToString() }
                                   equals new { ServiceProviderId = FavoriteAndBlocked.UserId.ToString(), UserId = FavoriteAndBlocked.TargetUserId.ToString() } into FavoriteAndBlocked_join
                                 from FavoriteAndBlocked in FavoriteAndBlocked_join.DefaultIfEmpty()
                                 where ServiceRequest.ServiceProviderId==userid
                                 select new FavoriteAndBlockeModel
                                 {
                                     FirstName = User.FirstName,
                                     LastName = User.LastName,
                                     TargetUserId = User.UserId,
                                     isBlocked = FavoriteAndBlocked.IsBlocked,
                                     UserId = FavoriteAndBlocked.UserId
                                 }).Distinct().ToList();

            var customer = new FavoriteAndBlockeModel()
            {
                blocked = blockcustomer
            };
            return View(customer);
        }

        [Route("/sp/mysetting")]
        public IActionResult MySetting()
        {
            var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userdetail = (from user in _helperlandContext.Users
                              join addresses in _helperlandContext.UserAddresses on user.UserId equals addresses.UserId into useraddress_join 
                              from addresses in useraddress_join.DefaultIfEmpty()
                              where user.UserId == userid
                              select new MyAccountModel
                              {
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  Email = user.Email,
                                  Mobile = user.Mobile,
                                  Avatar=user.UserProfilePicture,
                                  NatinalityId=user.NationalityId,
                                  Day = user.DateOfBirth.Value.Day,
                                  Month=user.DateOfBirth.Value.Month,
                                  Year=user.DateOfBirth.Value.Year,
                                  Gender=user.Gender,
                                  IsActive=user.IsActive,
                                  address= new AddressModel { 
                                    AddressLine1=addresses.AddressLine1,
                                    AddressLine2=addresses.AddressLine2,
                                    PostalCode=user.ZipCode,
                                    City=addresses.City
                                  },
                              }).FirstOrDefault();
            return View(userdetail);
        }

        [Route("/sp/mysetting")]
        [HttpPost]
        public JsonResult MySetting(MyAccountModel myAccountModel)
        {
            try
            {
                var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                var user = _helperlandContext.Users.Where(u => u.UserId == userid).FirstOrDefault();
                var useraddress = _helperlandContext.UserAddresses.Where(ua => ua.UserId == userid).FirstOrDefault();

                user.FirstName = myAccountModel.FirstName;
                user.LastName = myAccountModel.LastName;
                user.Mobile = myAccountModel.Mobile;
                user.NationalityId = myAccountModel.NatinalityId;
                user.Gender = myAccountModel.Gender;
                user.DateOfBirth = new DateTime((int)myAccountModel.Year, (int)myAccountModel.Month, (int)myAccountModel.Day, 0, 0, 0, 0); 
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = user.UserId;
                user.UserProfilePicture = myAccountModel.Avatar;
                user.ZipCode = myAccountModel.address.PostalCode;
                _helperlandContext.Users.Attach(user);

                if(useraddress != null)
                {
                    useraddress.AddressLine1 = myAccountModel.address.AddressLine1;
                    useraddress.AddressLine2 = myAccountModel.address.AddressLine2;
                    useraddress.PostalCode = myAccountModel.address.PostalCode;
                    useraddress.City = myAccountModel.address.City;
                    useraddress.Mobile = myAccountModel.Mobile;
                    useraddress.Email = myAccountModel.Email;
                }
                else
                {
                    useraddress = new UserAddress()
                    {
                        UserId=userid,
                        AddressLine1 = myAccountModel.address.AddressLine1,
                        AddressLine2 = myAccountModel.address.AddressLine2,
                        PostalCode = myAccountModel.address.PostalCode,
                        City = myAccountModel.address.City,
                        Mobile=myAccountModel.Mobile,
                        Email=myAccountModel.Email
                    };
                }
                _helperlandContext.UserAddresses.Attach(useraddress);
                _helperlandContext.SaveChanges();
                return Json(new { Result = true });
        }
            catch
            {
                return Json(new { Result = false ,Error="Internal Server Problem"});
            }

        }
    }
}
