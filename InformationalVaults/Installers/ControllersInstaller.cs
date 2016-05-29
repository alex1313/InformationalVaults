namespace InformationalVaults.Installers
{
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var apiControlllers = Classes
                .FromAssemblyNamed("InformationalVaults")
                .BasedOn<Controller>()
                .ConfigureFor<Controller>(cr => cr.PropertiesIgnore(pi => pi.Name == nameof(Controller.Request)))
                .LifestyleTransient();

            container.Register(apiControlllers);
        }
    }
}