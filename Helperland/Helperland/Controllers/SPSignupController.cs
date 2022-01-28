using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class SPSignupController : Controller
    {
        [Route("/sp-signup")]
        public IActionResult SPSignup()
        {
            ViewBag.title = "Become a Pro";
            ViewBag.js = "/JS/become_a_pro.js";
            ViewBag.css = "/CSS/become_a_pro.css";
            return View();
        }
    }
}
