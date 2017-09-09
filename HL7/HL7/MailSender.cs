using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace HL7
{
    public class MailSender
    {
        
        public void Sent(string kimden, string kime, string konu, string body)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587; //ssl portu
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true; //güvenlik için
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("nurcurukoglu@gmail.com", "40lb099AHMETONUR");
            MailMessage msg = new MailMessage();
            msg.Subject = konu;
            msg.Body = body;
            msg.From = new MailAddress(kimden);
            msg.To.Add(new MailAddress(kime));
            smtp.Send(msg);
        }
    }
}