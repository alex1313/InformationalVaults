namespace CQRS.Queries
{
    using System.Linq;
    using Criteria;
    using DomainModel.ViewModels;

    public class GetVaultConfigurationViewModelQuery : QueryBase<IdCriterion, VaultConfigurationViewModel>
    {
        public override VaultConfigurationViewModel Execute(IdCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var vault = uow.VaultRepository.GetById(criterion.Id);
                var vaultUserIds = vault.Users
                    .Select(x => x.Id)
                    .ToList();

                return new VaultConfigurationViewModel
                {
                    Id = vault.Id.ToString(),
                    Name = vault.Name,
                    Description = vault.Description,
                    OpenTime = vault.OpenTime,
                    CloseTime = vault.CloseTime,
                    Users = vaultUserIds
                };
            }
        }
    }
}