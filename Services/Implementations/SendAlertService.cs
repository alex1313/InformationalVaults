namespace Services.Implementations
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using DomainModel.Entities;

    public class SendAlertService : ISendAlertService
    {
        private static readonly IDictionary<string, PlaceholderValueProvider> Placeholders =
            new Dictionary<string, PlaceholderValueProvider>
            {
                ["USERNAME"] = x => x.User.Email,
                ["VAULTNAME"] = x => x.Vault.Name,
                ["DATETIMESTAMP"] = x => x.DateTimeStamp.ToString("F")
            };

        private readonly ISendEmailService _sendEmailService;

        public SendAlertService(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }

        public void CreateAndSendAccessDeniedAlert(VaultAccessLog vaultAccessLog, string recipientAddress)
        {
            var senderAddress = ConfigurationManager.AppSettings["SenderMailAddress"];
            var senderPassword = ConfigurationManager.AppSettings["SenderMailPassword"];
            var emailSubject = ConfigurationManager.AppSettings["EmailAlertSubject"];
            var alertTextTemplate = ConfigurationManager.AppSettings["EmailAlertTextTemplate"];

            var alertText = FillPlaceholders(alertTextTemplate, vaultAccessLog);
            _sendEmailService.SendEmail(senderAddress, senderPassword, recipientAddress, emailSubject, alertText);
        }

        private static string FillPlaceholders(string text, VaultAccessLog settings)
        {
            return Placeholders.Aggregate(text, (t, p) => t.Replace($"%{p.Key}%", p.Value(settings)));
        }

        private delegate string PlaceholderValueProvider(VaultAccessLog vaultAccessLog);
    }
}