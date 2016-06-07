namespace CQRS.Commands.Contexts
{
    using DomainModel.ViewModels;
    using Infrastructure;

    public class UpdateAdminsOfVaultsContext : ICommandContext
    {
        public UpdateAdminsOfVaultsContext(VaultAdminsViewModel[] vaultAdminsViewModels)
        {
            VaultAdminsViewModels = vaultAdminsViewModels;
        }

        public VaultAdminsViewModel[] VaultAdminsViewModels { get; set; }
    }
}