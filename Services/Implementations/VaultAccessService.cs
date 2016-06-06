namespace Services.Implementations
{
    using System;
    using DomainModel.Entities;

    public class VaultAccessService : IVaultAccessService
    {
        public bool IsUserHasAccess(User user, Vault vault)
        {
            return (user.Vaults.Contains(vault) || IsUserVaultAdmin(user, vault))
                   && IsOpenNow(vault.OpenTime, vault.CloseTime);
        }

        public bool IsUserVaultAdmin(User user, Vault vault)
        {
            return user.Id == vault.AdminId;
        }

        private static bool IsOpenNow(TimeSpan? openTime, TimeSpan? closeTime)
        {
            var currentTime = DateTime.Now.TimeOfDay;

            return (openTime.HasValue == false || currentTime >= openTime.Value)
                   && (closeTime.HasValue == false || currentTime <= closeTime.Value);
        }
    }
}