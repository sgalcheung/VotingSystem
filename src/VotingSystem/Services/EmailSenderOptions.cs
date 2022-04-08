namespace VotingSystem.Services
{
    public class EmailSenderOptions
    {
        public const string EmailSender = "EmailSender";

        public string MailUser { get; set; }
        public string MailPassword { get; set; }
        public string MailServer { get; set; }
    }
}
