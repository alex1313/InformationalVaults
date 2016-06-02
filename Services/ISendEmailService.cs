namespace Services
{
    public interface ISendEmailService
    {
        void SendEmail(string senderAddress, string senderPassword, string recipientAddress, string subject, string body);
    }
}