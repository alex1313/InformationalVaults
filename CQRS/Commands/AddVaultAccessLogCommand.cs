namespace CQRS.Commands
{
    using Contexts;
    using DomainModel.Entities;
    using Services;

    public class AddVaultAccessLogCommand : CommandBase<AddVaultAccessLogContext>
    {
        private readonly IVaultAccessService _vaultAccessService;

        public AddVaultAccessLogCommand(IVaultAccessService vaultAccessService)
        {
            _vaultAccessService = vaultAccessService;
        }

        public override void Execute(AddVaultAccessLogContext context)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var user = uow.UserRepository.GetById(context.UserId);
                var vault = uow.VaultRepository.GetById(context.VaultId);

                var haveAccess = _vaultAccessService.IsUserHasAccess(user, vault);

                var vaultAccessLog = new VaultAccessLog(context.UserId, context.VaultId, !haveAccess);

                uow.VaultAccessLogRepository.Insert(vaultAccessLog);
                uow.Commit();
            }
        }
    }
}