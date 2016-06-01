namespace CQRS.Queries.Criteria
{
    using Infrastructure;

    public class GetVaultViewModelsCriterion : ICriterion
    {
        public GetVaultViewModelsCriterion(int currentUserId)
        {
            CurrentUserId = currentUserId;
        }

        public int CurrentUserId { get; set; }
    }
}