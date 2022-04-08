using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;

namespace VotingSystem.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<EmailSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public EmailSenderOptions Options { get; }
        private const string FromDisplayName = "Voting System Notification";
        private const string TargetSubject = "New notifications in voting system";

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(subject, htmlMessage, email);
        }

        private Task Execute(string subject, string htmlMessage, string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(FromDisplayName, Options.MailUser));
            message.To.Add(new MailboxAddress(TargetSubject, email));
            message.Subject = subject;
            var builder = new BodyBuilder();
            builder.TextBody = htmlMessage;
            builder.HtmlBody = htmlMessage;
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(Options.MailServer, 587, SecureSocketOptions.None);
                client.Authenticate(Options.MailUser, Options.MailPassword);

                client.Send(message);
                client.Disconnect(true);
            }

            return Task.CompletedTask;
        }
    }
}
