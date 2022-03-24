using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Helperland.Models.Data;
using Helperland.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Helperland.Services.Email;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        public readonly HelperlandContext _helperlandContext = null;
        public readonly Email _email = new Email();
        public AdminController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        [Route("/admin/service-request")]
        public IActionResult ServiceRequest()
        {
            var services = (from ServiceRequest in _helperlandContext.ServiceRequests
                            join customer in _helperlandContext.Users on ServiceRequest.UserId equals customer.UserId
                            join address in _helperlandContext.ServiceRequestAddresses on ServiceRequest.ServiceRequestId equals address.ServiceRequestId
                            join serviceprovier in _helperlandContext.Users on ServiceRequest.ServiceProviderId equals  serviceprovier.UserId into serviceprovier_join
                            from serviceprovier in serviceprovier_join.DefaultIfEmpty()
                            join AvgTable in (
                                (from Rating in _helperlandContext.Ratings
                                 group Rating by new
                                 {
                                     Rating.RatingTo
                                 } into g
                                 select new
                                 {
                                     avgRating = (decimal?)g.Average(p => p.Ratings),
                                     g.Key.RatingTo
                                 })) on ServiceRequest.ServiceProviderId equals AvgTable.RatingTo into AvgTable_join
                            from AvgTable in AvgTable_join.DefaultIfEmpty()
                            select new AdminServiceRequest
                            {
                                ServiceId= ServiceRequest.ServiceId,
                                ServiceStartDate= ServiceRequest.ServiceStartDate,
                                ServiceHours= ServiceRequest.ServiceHours,
                                TotalCost= ServiceRequest.TotalCost,
                                RefundAmount=ServiceRequest.RefundedAmount,
                                Cust_firstname = customer.FirstName,
                                cust_lastname = customer.LastName,
                                AddressLine1= address.AddressLine1,
                                AddressLine2= address.AddressLine2,
                                PostalCode= address.PostalCode,
                                City= address.City,
                                ServiceProviderId = (int?)ServiceRequest.ServiceProviderId,
                                Profile=serviceprovier.UserProfilePicture,
                                sp_firstname = serviceprovier.FirstName,
                                sp_lastname = serviceprovier.LastName,
                                Status = (int?)ServiceRequest.Status,
                                avgRating = AvgTable.avgRating
                            }).ToList();

            var customerName =_helperlandContext.Users.Where(u=>u.UserTypeId==1).Select(u=>(u.FirstName+" "+u.LastName)).ToList();
            var sp =_helperlandContext.Users.Where(u=>u.UserTypeId==2).Select(u=>(u.FirstName+" "+u.LastName)).ToList();
            var serviceRequest = new AdminServiceRequest()
            {
                Customers= customerName,
                ServiceProvider=sp,
                serviceRequests = services
            };
            return View(serviceRequest);
        }

        [Route("/admin/getServiceDetail")]
        [HttpGet]
        public IActionResult GetServiceDetail(int serviceid)
        {
            var servicedetail = (from service in _helperlandContext.ServiceRequests
                                 join address in _helperlandContext.ServiceRequestAddresses on service.ServiceRequestId equals address.ServiceRequestId
                                 join user in _helperlandContext.Users on service.ServiceProviderId equals user.UserId into sp
                                 from serviceProvider in sp.DefaultIfEmpty()
                                 where service.ServiceId == serviceid
                                 select new ServiceDetailsModel
                                 {
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
                         where service.ServiceId == serviceid
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
            ViewBag.isHistory = true;
            return View(servicedetail);
        }

        [Route("/rescheduleAndEdit")]
        [HttpPost]
        public JsonResult RescheduleAndEdit(AdminServiceRequest adminServiceRequest)
        {
            var service = _helperlandContext.ServiceRequests.Where(s => s.ServiceId == adminServiceRequest.ServiceId).FirstOrDefault();
            var serviceAddress = _helperlandContext.ServiceRequestAddresses.Where(sa => sa.ServiceRequestId == service.ServiceRequestId).FirstOrDefault();
            if (service != null)
            {
                DateTime updatedStartTime = adminServiceRequest.ServiceStartDate;
                updatedStartTime = updatedStartTime.AddHours(Double.Parse(adminServiceRequest.ServiceStartTime));
                var updatedEndTime = updatedStartTime.AddHours(service.ServiceHours).AddHours(1);
                if (service.ServiceProviderId != null)
                {
                    var services = _helperlandContext.ServiceRequests.Where(s => s.ServiceProviderId == service.ServiceProviderId && s.Status == 2 && s.ServiceId != adminServiceRequest.ServiceId).ToList();
                    foreach (var s in services)
                    {
                        var serviceStart = s.ServiceStartDate;
                        var serviceEnd = s.ServiceStartDate.AddHours(s.ServiceHours).AddHours(1);
                        if ((updatedEndTime.CompareTo(serviceStart) > 0 && updatedEndTime.CompareTo(serviceEnd) <= 0) || (updatedStartTime.CompareTo(serviceStart) >= 0 && updatedStartTime.CompareTo(serviceEnd) < 0) || ((serviceStart.CompareTo(updatedStartTime) >= 0 && serviceEnd.CompareTo(updatedEndTime) < 0)))
                        {
                            return Json(new
                            {
                                Result = false,
                                error = "Another service request has been assigned to the service provider on " + serviceStart.ToString("dd/MM/yyyy") +
                            " from " + serviceStart.ToString("HH/mm") + " to " + serviceEnd.AddHours(-1).ToString("HH/mm") + ". Either choose another date or pick up a different time slot."
                            });
                        }
                    }
                }
                serviceAddress.AddressLine1 = adminServiceRequest.AddressLine1;
                serviceAddress.AddressLine2 = adminServiceRequest.AddressLine2;
                serviceAddress.PostalCode = adminServiceRequest.PostalCode;
                serviceAddress.City = adminServiceRequest.City;
                serviceAddress.ServiceRequest.ServiceStartDate = updatedStartTime;
                serviceAddress.ServiceRequest.ModifiedDate = DateTime.Now;
                serviceAddress.ServiceRequest.ModifiedBy = 5;

                var userEmail = _helperlandContext.Users.Where(u => u.UserId == service.UserId || u.UserId == service.ServiceProviderId).Select(s => s.Email).ToList();
                var email = new EmailModel()
                {
                    To = userEmail,
                    Subject = "Regarding Rechedule of service request",
                    isHTML = true,
                    Body = "Service Request " + service.ServiceId + " has been rescheduled by customer. New date and time are " + service.ServiceStartDate,
                };
                bool ismail = _email.sendMail(email);

                _helperlandContext.Attach(serviceAddress);
                _helperlandContext.SaveChanges();
                return Json(new { Result=true});
            }
            else
            {
                return Json(new { Result = false, error = "service request does not exists" });
            }
        }

        [Route("/refund")]
        [HttpPost]
        public JsonResult Refund(AdminServiceRequest adminServiceRequest)
        {
            var service = _helperlandContext.ServiceRequests.Where(s => s.ServiceId == adminServiceRequest.ServiceId).FirstOrDefault();
            if (service != null)
            {
                service.RefundedAmount = adminServiceRequest.RefundAmount;
                service.Comments = adminServiceRequest.RefundReason;
                service.Status = 5;
                service.ModifiedDate = DateTime.Now;
                service.ModifiedBy = 5;
                _helperlandContext.SaveChanges();
                return Json(new { result = true });
            }
            return Json(new { result = false, Error = "Internal Server Error" });
        }

        [Route("/admin/cancelrequest")]
        [HttpPost]
        public JsonResult CancelRequest(int id)
        {
            var service = _helperlandContext.ServiceRequests.Where(s => s.ServiceId == id).FirstOrDefault();
            if(service != null)
            {
                service.Status = 4;
                service.ModifiedDate = DateTime.Now;
                service.ModifiedBy = 5;

                _helperlandContext.ServiceRequests.Attach(service);

                var userEmail = (from user in _helperlandContext.Users
                                 from sr in _helperlandContext.ServiceRequests
                                 where (user.UserId == sr.UserId || user.UserId == sr.ServiceProviderId ) && sr.ServiceId==id
                                 select(user.Email)).ToList();
                var email = new EmailModel()
                {
                    To = userEmail,
                    Subject = "Regarding cancellation of service request",
                    isHTML = true,
                    Body = "Service Request has been Cancelled" ,
                };
                bool ismail = _email.sendMail(email);
                _helperlandContext.SaveChanges();
                return Json(new { result = true });
            }
            else
            {                
                return Json(new { result=false ,Error="Internal server error"});
            }
        }

        [Route("/admin/user-management")]
        public IActionResult UsersManagement()
        {
            var users = (from User in _helperlandContext.Users
                         join CityTable in (
                             (from Zipcode in _helperlandContext.Zipcodes
                              select new
                              {
                                  Zipcode.ZipcodeValue,
                                  Zipcode.City.CityName
                              })) on new { ZipCode = User.ZipCode } equals new { ZipCode = CityTable.ZipcodeValue } into CityTable_join
                         from CityTable in CityTable_join.DefaultIfEmpty()
                         select new AdminUserManagement
                         {
                            UserId= User.UserId,
                            UserName= User.FirstName+" "+User.LastName,
                            UserType= User.UserTypeId,
                            RegistrationDate= User.CreatedDate.ToString("dd/MM/yyyy").Replace("-","/"),
                            Phone= User.Mobile,
                            IsActive =User.IsActive,
                            PostalCode= User.ZipCode,
                            City=CityTable.CityName
                         }).ToList();
            var userManagement = new AdminUserManagement()
            {
                User = users
            };
            return View(userManagement);
        }

        [Route("/activation")]
        public JsonResult Activation(int userid)
        {
            try
            {
                var user = _helperlandContext.Users.Where(u => u.UserId == userid).FirstOrDefault();
                if (user != null)
                {
                    user.IsActive = !user.IsActive;

                    _helperlandContext.Users.Attach(user);
                    _helperlandContext.SaveChanges();

                    return Json(new { Result = true });
                }
                else
                {
                    return Json(new { Result = false ,Error="User not found"});
                }
            }
            catch
            {
                return Json(new {Result=false,Error="Internal Server Error"});
            }
        }
    }
}
