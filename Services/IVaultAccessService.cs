namespace Services
{
    using DomainModel.Entities;

    public interface IVaultAccessService
    {
        bool IsUserHasAccess(User user, Vault vault);

        bool IsUserVaultAdmin(User user, Vault vault);
    }
}