﻿namespace InformationalVaults
{
    using System.Data.Entity;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using DataAccess;
    using DataAccess.Migrations;
    using Installers;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IocContainer.Setup();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InformationalVaultsContext, MigrationsConfiguration>());
        }
    }
}   