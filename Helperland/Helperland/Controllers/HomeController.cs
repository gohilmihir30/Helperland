using Helperland.Models;
using Helperland.Models.Data;
using Helperland.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Security.Cryptography;
using Microsoft.AspNetCore.DataProtection;
using Helperland.Services.Email;

namespace Helperland.Controllers
{
    public class HomeController : Controller
    {
        public readonly HelperlandContext _helperlandContext;
        public readonly IDataProtector _protector;
        public readonly string DataProtectionString = "key";
        public readonly Email _email = new Email();
        public HomeController(HelperlandContext helperlandContext, IDataProtectionProvider protector)
        {
            _helperlandContext = helperlandContext;
            _protector = protector.CreateProtector(DataProtectionString);
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/")]
        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            var isExist = _helperlandContext.Users.Where(x => x.Email.Equals(loginModel.Username)).FirstOrDefault();

            if (isExist == null)
            {
                TempData["isValidCredentials"] = false;
                return RedirectToAction("index", new { modalRequest = "true" });
            }
            else
            {
                var verified = Crypto.VerifyHashedPassword(isExist.Password, loginModel.Password);
                if (!verified)
                {
                    TempData["isValidCredentials"] = false;
                    return RedirectToAction("index", new { modalRequest = "true" });
                }else if (!isExist.IsActive)
                {
                    TempData["isActive"] = false;
                    return RedirectToAction("index", new { modalRequest = "true" });
                }
                else
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim("username", isExist.Email));
                    if (isExist.UserTypeId == 1)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Customer"));
                    }else if (isExist.UserTypeId == 2 )
                    {
                        claims.Add(new Claim(ClaimTypes.Role,"ServiceProvider"));
                    }
                    else if (isExist.UserTypeId == 3)
                    {
                        claims.Add(new Claim(ClaimTypes.Role,"Admin"));
                    }
                    var role =claims.Where(c => c.Type == ClaimTypes.Role).Select(c=>c.Value).SingleOrDefault();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, isExist.UserId.ToString()));
                    claims.Add(new Claim(ClaimTypes.MobilePhone, isExist.Mobile));
                    claims.Add(new Claim(ClaimTypes.Name, isExist.FirstName + " " + isExist.LastName));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties
                    {
                        IsPersistent = loginModel.RememberMe
                    }) ;
                    if (role == "Customer")
                    {
                        return RedirectToAction("Dashboard", "Customer");
                    }else if(role == "ServiceProvider")
                    {
                        return RedirectToAction("Dashboard", "ServiceProvider");
                    }else if(role == "Admin")
                    {
                        return RedirectToAction("UsersManagement", "Admin");
                    }
                    return RedirectToAction("index");
                }
            }
        }


        [Route("/logout")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index");
        }

        [Route("/forgetpass")]
        [HttpPost]
        public IActionResult ForgetPass(LoginModel loginModel)
        {
            var id = _helperlandContext.Users.FirstOrDefault(e => e.Email == loginModel.Email);
            string encyptedId = _protector.Protect(loginModel.Email + "_" + id.UserId + "_" + DateTime.UtcNow);
            var email = new EmailModel()
            {
                To = new List<string> { loginModel.Email },
                Subject = "Password reset of your account in helperland",
                isHTML = true,
                Body = "Hi!! You request to reset your password, please click below link to reset your password.<p><a href='http://localhost:47474/resetpass?id=" + encyptedId + "'>http://localhost:47474/resetpass?id=" + encyptedId + "</a></p>",
            };
            _email.sendMail(email);
            return RedirectToAction("index");
        }

        [Route("/resetpass")]
        [HttpGet]
        public IActionResult resetPass(string id)
        {
            try
            {
                var decryptId = _protector.Unprotect(id);
                DateTime expiryDate = DateTime.Parse(decryptId.Split("_")[2]).AddHours(5);
                DateTime current = DateTime.UtcNow;
                int isvalid = current.CompareTo(expiryDate);

                if (isvalid > 0)
                {
                    throw new Exception();
                }
                return View();
            }
            catch
            {
                return BadRequest(error: "Invalid Link");
            }
        }

        [Route("/resetpass")]
        [HttpPost]
        public IActionResult resetPass(resetPassModel resetPassModel, string id)
        {
            string decryptId = _protector.Unprotect(id);
            if (decryptId != null)
            {
                int userId = Convert.ToInt32(decryptId.Split("_")[1]);
                var user = _helperlandContext.Users.Where(e => e.UserId == userId).FirstOrDefault();
                user.Password = Crypto.HashPassword(resetPassModel.NewPassword);
                _helperlandContext.Users.Attach(user);
                _helperlandContext.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                TempData["isvalid"] = false;
                return RedirectToAction("resetPass");
            }
        }

        [Authorize(Roles = "Customer,ServiceProvider,Admin")]
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

        [Authorize(Roles = "Customer,ServiceProvider")]
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
                    var isVerified = Crypto.VerifyHashedPassword(user.Password, myAccountModel.OldPassword);
                    if (!isVerified)
                    {
                        return Json(new { Result = false, Error = "Old Password is Incorrect!" });
                    }
                    user.Password = Crypto.HashPassword(myAccountModel.NewPassword);
                    user.ModifiedDate = DateTime.Now;
                    user.ModifiedBy = userid;
                    _helperlandContext.Users.Attach(user);
                    _helperlandContext.SaveChanges();
                    return Json(new { Result = true });
                }
                return Json(new { Result = false, Error = "Internal Server Error" });
            }
            catch
            {
                return Json(new { Result = false, Error = "Internal Server Error" });
            }
        }

        [Authorize(Roles = "Customer,ServiceProvider")]
        [Route("/blockcustomer")]
        [HttpPost]
        public JsonResult BlockCustomer(int customerid,bool favorite)
        {
            try
            {
                var userid = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                var blocked = _helperlandContext.FavoriteAndBlockeds.Where(c => c.UserId == userid && c.TargetUserId == customerid).FirstOrDefault();
                if (blocked != null)
                {
                    if((blocked.IsBlocked && favorite) || (blocked.IsFavorite && !favorite))
                    {
                        string Error = (favorite) ? "You can't add to favorite list, you already blocked this SP" : "You can't blocked this SP, already in favorite list";
                        return Json(new { result = false, Error = Error });
                    }
                    _helperlandContext.FavoriteAndBlockeds.Remove(blocked);
                }
                else
                {
                    var favoriteAndBlockednew = new FavoriteAndBlocked()
                    {
                        UserId = userid,
                        TargetUserId = customerid,
                        IsFavorite = favorite,
                        IsBlocked = !favorite
                    };
                    _helperlandContext.FavoriteAndBlockeds.Add(favoriteAndBlockednew);
                }
                _helperlandContext.SaveChanges();
                return Json(new { result = true });
            }
            catch
            {
                return Json(new { result = false, Error = "Internal Server Error" });
            }
        }
    }
}
