using System;
using System.Diagnostics;
using System.Net.Mail;

namespace TheWorld.Services.SentMessageToGmail
{
    public class GMailSMTP
    {
       
      
        public void SendMessage(string to, string from, string subject, string body)
        {
            SmtpClient SmtpClient = new SmtpClient();
            SmtpClient.Credentials = new System.Net.NetworkCredential("maximkalin12", "maxim147852");
            SmtpClient.Port = 587;
            SmtpClient.Host = "smtp.gmail.com";
            SmtpClient.EnableSsl = true;
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mail = new MailMessage();
            
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(to));
                mail.Subject = subject;
                mail.Body = body;

            try
            {
                SmtpClient.Send(mail);
                Debug.Write("Message sent");
            }
            catch (Exception e) {
                Debug.Write(e.Message);
                Debug.Write("Fault");
            }; 
        }
    }
}
