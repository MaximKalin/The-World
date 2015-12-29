using TheWorld.Services.SentMssageToGmail;

namespace TheWorld.Services
{
    public class ProdMailService : IMailService
    {
        public bool SendMail(string to, string from, string subject, string body)
        {
            GMailSMTP mailService = new GMailSMTP();
            mailService.SendMessage(to, from, subject, body);
            return true;
        }
    }
}