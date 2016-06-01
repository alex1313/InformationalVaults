namespace CQRS.Queries
{
    using System.Linq;
    using Criteria;
    using DomainModel.Entities;

    public class GetAllVaultsQuery : QueryBase<EmptyCriterion, Vault[]>
    {
        public override Vault[] Execute(EmptyCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                return uow.VaultRepository
                    .GetAll()
                    .ToArray();
            }
        }
    }
}