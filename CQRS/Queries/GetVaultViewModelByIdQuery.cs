namespace CQRS.Queries
{
    using Criteria;
    using DomainModel.ViewModels;

    public class GetVaultViewModelByIdQuery : QueryBase<IdCriterion, VaultViewModel>
    {
        public override VaultViewModel Execute(IdCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var vault = uow.VaultRepository
                    .GetById(criterion.Id);

                return new VaultViewModel
                {
                    Id = vault.Id.ToString(),
                    Name = vault.Name,
                    Description = vault.Description,
                    AdminEmail = vault.Admin.Email
                };
            }
        }
    }
}