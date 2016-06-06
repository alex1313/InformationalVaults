namespace CQRS.Queries
{
    using Criteria;

    public class IsUserSuperAdminQuery : QueryBase<IdCriterion, bool>
    {
        public override bool Execute(IdCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var user = uow.UserRepository.GetById(criterion.Id);

                return user.Role.Name.ToLower() == "admin";
            }
        }
    }
}