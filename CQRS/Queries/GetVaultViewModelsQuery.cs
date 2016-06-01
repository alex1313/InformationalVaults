namespace CQRS.Queries
{
    using System.Linq;
    using Criteria;
    using DomainModel.ViewModels;
    using Services;

    public class GetVaultViewModelsQuery : QueryBase<GetVaultViewModelsCriterion, VaultViewModel[]>
    {
        private readonly IVaultAccessService _vaultAccessService;

        public GetVaultViewModelsQuery(IVaultAccessService vaultAccessService)
        {
            _vaultAccessService = vaultAccessService;
        }

        public override VaultViewModel[] Execute(GetVaultViewModelsCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var currentUser = uow.UserRepository
                    .GetById(criterion.CurrentUserId);

                return uow.VaultRepository
                    .GetAll()
                    .Select(x => new VaultViewModel
                    {
                        Id = x.Id.ToString(),
                        Name = x.Name,
                        Description = x.Description,
                        ShowLinkToAccessLogs = x.VaultAccessLogs.Any() && _vaultAccessService.IsUserAdmin(currentUser, x)
                    })
                    .ToArray();
            }
        }
    }
}