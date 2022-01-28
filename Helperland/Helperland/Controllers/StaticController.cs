using Helperland.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class StaticController : Controller
    {
        private readonly HelperlandContext _helperlandContext=null;

        public StaticController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        [Route("/faq")]
        public IActionResult Faq()
        {
            ViewBag.title = "FAQ | Helperland";
            ViewBag.css = "/CSS/faq.css";
            ViewBag.js = "/JS/faq.js";
            return View();
        }

        [Route("/prices")]
        public IActionResult Prices()
        {
            ViewBag.title = "Prices | Helperland";
            ViewBag.css = "/CSS/prices.css";
            ViewBag.js = "/JS/prices.js";
            return View();
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            ViewBag.title = "Contact | Helperland";
            ViewBag.css = "/CSS/contact.css";
            ViewBag.js = "/JS/contact.js";
            return View();
        }

        [Route("/contact")]
        [HttpPost]
        public IActionResult contact(ContactU contact)
        {
            ViewBag.title = "Contact | Helperland";
            ViewBag.css = "/CSS/contact.css";
            ViewBag.js = "/js/contact.js";

            return View();
        }
        [Route("/about")]
        public IActionResult About()
        {
            ViewBag.title = "About US | Helperland";
            ViewBag.css = "/CSS/about.css";
            ViewBag.js = "/JS/about.js";
            return View();
        }
    }
}
