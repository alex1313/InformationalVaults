namespace Services
{
    using DomainModel.Entities;

    public interface ISendAlertService
    {
        void CreateAndSendAccessDeniedAlert(VaultAccessLog vaultAccessLog, string recipientAddress);
    }
}