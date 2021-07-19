using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ShineWay.Classes
{
    class Emails
    {
        public static void sendEmail(String to, String subject, string messageBody)
        {
            MailMessage message = new MailMessage("ShineWayRentalLk@gmail.com", to);
            message.Subject = subject;
            message.Body = messageBody;
            SmtpClient client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ShineWayRentalLk@gmail.com", "shineway@123"),
                EnableSsl = true,
            };

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }

        }
    }
}
