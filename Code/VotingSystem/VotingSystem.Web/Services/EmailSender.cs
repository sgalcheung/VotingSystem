using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;

namespace VotingSystem.Web.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } // set only via Secret Manger
        private const string SENDEMAIL = "sgalwork@outlook.com";

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(Options.SendEmailKey, subject, htmlMessage, email);
        }

        private Task Execute(string apiKey, string subject, string htmlMessage, string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Options.SendEmailUser, SENDEMAIL));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;
            var builder = new BodyBuilder();
            builder.TextBody = htmlMessage;
            builder.HtmlBody = htmlMessage;
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, false);
                client.Authenticate(SENDEMAIL, Options.SendEmailKey);

                client.Send(message);
                client.Disconnect(true);
            }

            return Task.CompletedTask;
        }
    }
}
