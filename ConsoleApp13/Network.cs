using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class Network
    {
        public void SendMail(string recipientEmail)
        {
            string subject = "Boss Az Code";
            string body = "123456";
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("hesenavs1@gmail.com", "nyvc brqn ttec pbsv");
            smtpClient.EnableSsl = true;

            message.From = new MailAddress("hesenavs1@gmail.com");
            message.To.Add(new MailAddress(recipientEmail));
            message.Subject = subject;
            message.Body = body;

            smtpClient.Send(message);
        }
    }
}
