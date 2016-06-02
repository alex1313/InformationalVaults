namespace CQRS.Queries.Criteria
{
    using DomainModel.Entities;
    using Infrastructure;

    public class GetAllVaultViewModelsCriterion : ICriterion
    {
        public GetAllVaultViewModelsCriterion(User currentUser)
        {
            CurrentUser = currentUser;
        }

        public User CurrentUser { get; set; }
    }
}