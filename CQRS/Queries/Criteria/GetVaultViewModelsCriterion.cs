namespace CQRS.Queries.Criteria
{
    using DomainModel.Entities;
    using Infrastructure;

    public class GetVaultViewModelsCriterion : ICriterion
    {
        public GetVaultViewModelsCriterion(User currentUser)
        {
            CurrentUser = currentUser;
        }

        public User CurrentUser { get; set; }
    }
}