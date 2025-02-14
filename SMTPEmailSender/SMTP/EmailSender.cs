using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace ConsoleApp10.SMTP
{
    internal class EmailSender
    {
        public void sendMail(string to, string subject, string content)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            smtpClient.Credentials = new NetworkCredential("yourgmail@gmail.com", "XXXX XXXX XXXX XXXX"); // update your SMTP Sender credentials to use
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("yourgmail@gmail.com"); // update you gmail
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = content;
            mailMessage.IsBodyHtml = true; // set this false if you are not using html/css tags as mail body

            smtpClient.Send(mailMessage);
        }
    }
}
