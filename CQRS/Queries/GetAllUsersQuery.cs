namespace CQRS.Queries
{
    using System.Linq;
    using Criteria;
    using DomainModel.Entities;

    public class GetAllUsersQuery : QueryBase<EmptyCriterion, User[]>
    {
        public override User[] Execute(EmptyCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                return uow.UserRepository
                    .GetAll()
                    .ToArray();
            }
        }
    }
}