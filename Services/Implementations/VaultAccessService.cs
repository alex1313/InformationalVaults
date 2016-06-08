namespace Services.Implementations
{
    using System;
    using DomainModel.Entities;
    using Providers;

    public class VaultAccessService : IVaultAccessService
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public VaultAccessService(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public bool IsUserHasAccess(User user, Vault vault)
        {
            return (user.Vaults.Contains(vault) || IsUserVaultAdmin(user, vault))
                   && IsOpenNow(vault.OpenTime, vault.CloseTime);
        }

        public bool IsUserVaultAdmin(User user, Vault vault)
        {
            return user.Id == vault.AdminId;
        }

        private bool IsOpenNow(TimeSpan? openTime, TimeSpan? closeTime)
        {
            var currentTime = _dateTimeProvider.PresentTime;

            return (openTime.HasValue == false || currentTime >= openTime.Value)
                   && (closeTime.HasValue == false || currentTime <= closeTime.Value);
        }
    }
}