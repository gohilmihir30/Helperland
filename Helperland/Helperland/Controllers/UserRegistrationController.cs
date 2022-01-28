using Helperland.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class UserRegistrationController : Controller
    {

        [Route("/userRegistration")]
        [HttpGet]
        public ActionResult userRegistration()
        {
            ViewBag.title = "Create an Account | Helperland";
            ViewBag.js = "/JS/userRegistration.js";
            ViewBag.css = "/CSS/userRegistration.css";
            return View();
        }


        [Route("/userRegistration")]
        [HttpPost]
        public ActionResult userRegistration(Models.Data.User user)
        {
            ViewBag.title = "Create an Account | Helperland";
            ViewBag.js = "/JS/userRegistration.js";
            ViewBag.css = "/CSS/userRegistration.css";
           
            return View();
        }
    }
}
