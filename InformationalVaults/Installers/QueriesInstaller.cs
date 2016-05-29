namespace InformationalVaults.Installers
{
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using CQRS.Queries.Infrastructure;

    public class QueriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();;

            var queires = Classes
                .FromAssemblyInDirectory(new AssemblyFilter("./bin", "CQRS*"))
                .BasedOn(typeof(IQuery<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient();

            container.Register(
                queires,
                Component.For<IQueryBuilder>().AsFactory().LifestyleSingleton(),
                Component.For<IQueryFactory>().AsFactory().LifestyleSingleton(),
                Component.For(typeof(IQueryDescriptor<>)).ImplementedBy(typeof(QueryDescriptor<>)).LifestyleSingleton()
                );
        }
    }
}