namespace CQRS.Commands.Contexts
{
    using DomainModel.Entities;
    using Infrastructure;

    public class AddVaultAccessLogContext : ICommandContext
    {
        public AddVaultAccessLogContext(int userId, int vaultId)
        {
            UserId = userId;
            VaultId = vaultId;
        }

        public int UserId { get; set; }
        public int VaultId { get; set; }

        public VaultAccessLog CreatedVaultAccessLog { get; set; }
    }
}