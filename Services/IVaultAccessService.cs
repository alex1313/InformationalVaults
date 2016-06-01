namespace Services
{
    using DomainModel.Entities;

    public interface IVaultAccessService
    {
        bool IsUserHasAccess(User user, Vault vault);
    }
}