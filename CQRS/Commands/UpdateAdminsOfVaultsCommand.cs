namespace CQRS.Commands
{
    using Contexts;

    public class UpdateAdminsOfVaultsCommand : CommandBase<UpdateAdminsOfVaultsContext>
    {
        public override void Execute(UpdateAdminsOfVaultsContext context)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                foreach (var viewModel in context.VaultAdminsViewModels)
                {
                    var vault = uow.VaultRepository.GetById(viewModel.Id);
                    if (vault == null || vault.AdminId == viewModel.AdminId)
                        continue;

                    vault.AdminId = viewModel.AdminId;

                    uow.VaultRepository.Update(vault);
                    uow.Commit();
                }
            }
        }
    }
}