namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class MigrationsConfiguration : DbMigrationsConfiguration<InformationalVaultsContext>
    {
        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DataAccess.InformationalVaultsContext";
        }

        protected override void Seed(InformationalVaultsContext context)
        {
        }
    }
}