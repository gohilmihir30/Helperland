using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using Helperland.Models.ViewModels;

namespace Helperland.Services.Email
{
    public class Email
    {
        public Boolean sendMail(EmailModel email)
        {
            try
            {
                MailMessage mm = new MailMessage()
                {
                    From = new MailAddress("tpass3506@gmail.com")
                };
                mm.To.Add(email.To);
                mm.Subject = email.Subject;
                mm.Body = email.Body;
                mm.IsBodyHtml = email.isHTML;
                if (email.Attachment != null)
                    mm.Attachments.Add(new Attachment(email.Attachment));

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("tpass3506@gmail.com", "Mihir@1322"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mm);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
