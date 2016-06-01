namespace CQRS.Queries
{
    using System.Linq;
    using Criteria;
    using DomainModel.Entities;

    public class GetUserByName : QueryBase<NameCriterion, User>
    {
        public override User Execute(NameCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                return uow.UserRepository
                    .Get(x => x.Email == criterion.Name)
                    .FirstOrDefault();
            }
        }
    }
}