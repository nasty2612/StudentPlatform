using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace StudentPlatform.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var client = new SmtpClient("smtp.mail.ru", 587))
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("bnastya261206@mail.ru", "dMQ24vTWc7F124dFQHNa");

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("bnastya261206@mail.ru", "StudentPlatform"),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(email);
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
