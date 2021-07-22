using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShineWay.Classes
{
    class Emails
    {
        //from microsoft documentation but modified
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

        //from web

        public static void Email(string email, string recipient, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ShineWayRentalLk@gmail.com", "shineway@123"),
                EnableSsl = true,
            };
            try
            {
                smtpClient.Send(email, recipient, subject, body);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public static string createEmailTemplate(string name, string userName, string password)
        {
            string body = string.Empty;
            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("ShineWay.Template.html"));

            body = reader.ReadToEnd();
            /*body = body.Replace("{name}", name);
            body = body.Replace("{userName}", userName);
            body = body.Replace("{password}", password);*/

            return body;
        }
    }
}
