namespace CQRS.Queries
{
    using Criteria;
    using DomainModel.Entities;
    using Infrastructure;

    public class GetVaultByIdQuery : QueryBase<IdCriterion, Vault>
    {
        public override Vault Execute(IdCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                return uow.VaultRepository
                    .GetById(criterion.Id);
            }
        }
    }
}