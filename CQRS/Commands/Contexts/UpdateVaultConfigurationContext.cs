namespace CQRS.Commands.Contexts
{
    using DomainModel.ViewModels;
    using Infrastructure;

    public class UpdateVaultConfigurationContext : ICommandContext
    {
        public UpdateVaultConfigurationContext(VaultConfigurationViewModel configuration)
        {
            Configuration = configuration;
        }

        public VaultConfigurationViewModel Configuration { get; set; }
    }
}