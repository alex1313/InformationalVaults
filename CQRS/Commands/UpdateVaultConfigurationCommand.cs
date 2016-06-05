namespace CQRS.Commands
{
    using Contexts;

    public class UpdateVaultConfigurationCommand : CommandBase<UpdateVaultConfigurationContext>
    {
        public override void Execute(UpdateVaultConfigurationContext context)
        {
            var configuration = context.Configuration;

            using (var uow = UnitOfWorkFactory.Create())
            {
                var vault = uow.VaultRepository.GetById(configuration.Id);

                vault.Name = configuration.Name;
                vault.Description = configuration.Description;
                vault.OpenTime = configuration.OpenTime;
                vault.CloseTime = configuration.CloseTime;

                uow.VaultRepository.Update(vault);

                uow.Commit();
            }
        }
    }
}