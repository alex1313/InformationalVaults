namespace CQRS.Queries.Criteria
{
    using Infrastructure;

    public class GetVaultAccessLogViewModelsForLastDayContext : ICriterion
    {
        public GetVaultAccessLogViewModelsForLastDayContext(int vaultId)
        {
            VaultId = vaultId;
        }

        public int VaultId { get; set; }
    }
}