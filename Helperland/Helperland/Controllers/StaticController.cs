using Helperland.Models.Data;
using Helperland.Models.ViewModels;
using Helperland.Services.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class StaticController : Controller
    {
        private readonly HelperlandContext _helperlandContext = null;
        private readonly IWebHostEnvironment _iwebhostenvironment;
        private readonly Email _email = null;

        public StaticController(HelperlandContext helperlandContext, IWebHostEnvironment webHostEnvironment)
        {
            _helperlandContext = helperlandContext;
            _iwebhostenvironment = webHostEnvironment;
            _email = new Email();
        }
        [Route("/faq")]
        public IActionResult Faq()
        {
            return View();
        }

        [Route("/prices")]
        public IActionResult Prices()
        {
            return View();
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("/contact")]
        [HttpPost]
        public IActionResult Contact(contactUsForm contact)
        {
            try
            {
                string uploadedFile = null;
                string serverFolder = null;
                if (ModelState.IsValid)
                {
                    if (contact.FilePath != null)
                    {
                        uploadedFile = "ContactUsFiles/";
                        uploadedFile += Guid.NewGuid().ToString() + contact.FilePath.FileName;
                        serverFolder = Path.Combine(_iwebhostenvironment.WebRootPath, uploadedFile);
                        using (var filestream = new FileStream(serverFolder, FileMode.Create))
                        {
                            contact.FilePath.CopyTo(filestream);
                        }
                    }
                    var email = new EmailModel()
                    {
                        To = "admin@gmail.com",
                        Subject = "Regarding " + contact.Subject,
                        isHTML = true,
                        Body = "Hi!! <br>My name is <b>" + contact.FirstName + " " + contact.LastName + ".</b> My Email is <b>" + contact.Email + "</b><br> <p>" + contact.Message + "</p><p> Please contact me on this mail as soon as possible.</p>",
                        Attachment = serverFolder
                    };
                    var newContactU = new ContactU()
                    {
                        Name = contact.FirstName + contact.LastName,
                        Email = contact.Email,
                        Subject = contact.Subject,
                        PhoneNumber = contact.PhoneNumber,
                        Message = contact.Message,
                        UploadFileName = uploadedFile,
                        CreatedOn = DateTime.Now,
                        CreatedBy=0
                    };
                    var isEmailSend = _email.sendMail(email);
                    if (!isEmailSend)
                    {
                        throw new Exception();
                    }
                    _helperlandContext.ContactUs.Add(newContactU);
                    _helperlandContext.SaveChanges();
                }
                TempData["Error"] = false;
                return RedirectToAction("contact");
            }
            catch
            {
                TempData["Error"] = true;
                return RedirectToAction("contact");
            }
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
