using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailEngine
{
    public class EmailService
    {
        string fromAddress { get; }
        string fromPassword { get; }

        SmtpClient emailClient { get; }

        public EmailService()
        {
            this.fromAddress = "itsmemesoclock@gmail.com";
            this.fromPassword = "Memememe55";

            this.emailClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress, fromPassword)
            };
        }

        public void SendEmail(string toAddress,
            string subject,
            string body,
            bool isHtml = false)
        {
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = isHtml
            })
            {
                emailClient.Send(message);
            }
        }

        public void SendEmailWithImagesInBody(string toAddress,
            string subject,
            IEnumerable<string> imgUrls,
            IEnumerable<string> customMessages = null)
        {
            string body = "<html><body>";

            // append custom messages
            if (customMessages != null)
            {
                foreach (var message in customMessages)
                {
                    body += string.Format("<span>{0}</span><br>", message);
                }
            }

            // append img urls
            foreach (var url in imgUrls)
            {
                body += string.Format("<img src=\"{0}\" width=400 style=\"margin-top:10px; margin-bottom:10px; border:1px black solid\"/>", url);
            }

            body += "</body></html>";

            SendEmail(toAddress, subject, body, true);
        }
    }
}
