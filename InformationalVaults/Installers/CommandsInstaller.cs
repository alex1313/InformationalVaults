namespace InformationalVaults.Installers
{
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using CQRS.Commands.Infrastructure;

    public class CommandsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var commands = Classes
                .FromAssemblyInDirectory(new AssemblyFilter("./bin", "CQRS*"))
                .BasedOn(typeof (ICommand<>))
                .WithService.AllInterfaces()
                .LifestyleTransient();

            container.Register(
                commands,
                Component.For<ICommandBuilder>().ImplementedBy<CommandBuilder>().LifestyleSingleton(),
                Component.For<ICommandFactory>().AsFactory().LifestyleSingleton()
                );
        }
    }
}