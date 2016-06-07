namespace CQRS.Queries
{
    using System.Linq;
    using Criteria;
    using DomainModel.ViewModels;
    using Services;

    public class GetAllVaultViewModelsQuery : QueryBase<GetAllVaultViewModelsCriterion, VaultViewModel[]>
    {
        private readonly IVaultAccessService _vaultAccessService;

        public GetAllVaultViewModelsQuery(IVaultAccessService vaultAccessService)
        {
            _vaultAccessService = vaultAccessService;
        }

        public override VaultViewModel[] Execute(GetAllVaultViewModelsCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                return uow.VaultRepository
                    .GetAll()
                    .Select(x => new VaultViewModel
                    {
                        Id = x.Id.ToString(),
                        Name = x.Name,
                        Description = x.Description,
                        IsCurrentUserVaultAdmin = _vaultAccessService.IsUserVaultAdmin(criterion.CurrentUser, x),
                        HasAccessLogs = x.VaultAccessLogs.Any()
                    })
                    .ToArray();
            }
        }
    }
}