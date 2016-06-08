namespace Services.Implementations
{
    using System.Net;
    using System.Net.Mail;

    public class GmailSendEmailService : ISendEmailService
    {
        public void SendEmail(string senderAddress, string senderPassword, string recipientAddress, string subject, string body)
        {
            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress(senderAddress);
                mail.To.Add(recipientAddress);
                mail.Subject = subject;
                mail.Body = body;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(senderAddress, senderPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}