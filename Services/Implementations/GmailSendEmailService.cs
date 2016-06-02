namespace Services.Implementations
{
    using System.Net;
    using System.Net.Mail;

    public class GmailSendEmailService : ISendEmailService
    {
        public void SendEmail(string senderAddress, string senderPassword, string recipientAddress, string subject, string body)
        {
            var senderMailAddress = new MailAddress(senderAddress);

            var recipientMailAddress = new MailAddress(recipientAddress);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(recipientMailAddress.Address, senderPassword)
            };

            using (var mail = new MailMessage(senderMailAddress, senderMailAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(mail);
            }
        }
    }
}