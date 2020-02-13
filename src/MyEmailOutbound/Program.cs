using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyEmailOutbound
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Message Sending...");
            var client = new SmtpClient()
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("alf.drms@gmail.com", "xxxxxx")
            };
            var from = new MailAddress("alf.drms@gmail.com", "Chen Angelo");
            var to = new MailAddress("worameth.s@bcircle.co.th");

            var message = new MailMessage(from, to);
            message.Body = "This is a body.";
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = "This is subject";
            message.SubjectEncoding = Encoding.UTF8;

            MailAddress copy = new MailAddress("chenzaza@gmail.com");
            message.CC.Add(copy);

            await client.SendMailAsync(message); // need handle exception...

            Console.WriteLine("Message sended.");
            Console.ReadLine();
        }
    }
}
