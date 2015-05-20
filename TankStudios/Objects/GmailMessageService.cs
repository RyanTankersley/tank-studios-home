using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using TankStudios.Interfaces;

namespace TankStudios.Objects
{
    public class GmailMessageService : IContactService
    {
        public Task<bool> SendContactMessage(string fName, string lName, string email, string message)
        {
            try
            {
                return Task.Run<bool>(() =>
                {
                    var mail = new MailMessage();

                    var smtpServer = new SmtpClient("smtp.gmail.com");
                    smtpServer.Credentials = new System.Net.NetworkCredential("tankstudios.ryantankersley@gmail.com", "TankStudios1234!");
                    smtpServer.Port = 587;
                    smtpServer.Host = "smtp.gmail.com";
                    smtpServer.EnableSsl = true;

                    mail.From = new MailAddress("tankstudios.ryantankersley@gmail.com");
                    mail.To.Add("ry.tankersley@gmail.com");
                    mail.Subject = "Somebody Contacted You!";
                    mail.Body = string.Format("{0} {1}\n{2}\n\n{3}", fName, lName, email, message);

                    smtpServer.Send(mail);
                    return true;
                });
            }
            catch
            {
                return Task.Run<bool>(() => { return false; });
            }
            
        }
    }
}