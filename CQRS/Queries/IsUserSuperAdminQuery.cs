namespace CQRS.Queries
{
    using Criteria;
    using DomainModel.Definitions;

    public class IsUserSuperAdminQuery : QueryBase<IdCriterion, bool>
    {
        public override bool Execute(IdCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var user = uow.UserRepository.GetById(criterion.Id);

                return user.Role.Name == RoleNames.Administrator;
            }
        }
    }
}