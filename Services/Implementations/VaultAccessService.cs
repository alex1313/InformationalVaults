namespace Services.Implementations
{
    using DomainModel.Entities;

    public class VaultAccessService : IVaultAccessService
    {
        public bool IsUserHasAccess(User user, Vault vault)
        {
            return user.Vaults.Contains(vault);
        }
    }
}