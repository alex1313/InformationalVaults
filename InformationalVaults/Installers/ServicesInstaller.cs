namespace InformationalVaults.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Services;
    using Services.Implementations;
    using Services.Providers;

    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDateTimeProvider>().ImplementedBy<DateTimeProvider>());

            container.Register(Component.For<IVaultAccessService>().ImplementedBy<VaultAccessService>(),
                Component.For<ISendAlertService>().ImplementedBy<SendAlertService>(),
                Component.For<ISendEmailService>().ImplementedBy<GmailSendEmailService>());
        }
    }
}