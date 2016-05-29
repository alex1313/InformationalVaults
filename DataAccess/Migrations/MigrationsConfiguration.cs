namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DomainModel.Entities;

    public sealed class MigrationsConfiguration : DbMigrationsConfiguration<InformationalVaultsContext>
    {
        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DataAccess.InformationalVaultsContext";
        }

        protected override void Seed(InformationalVaultsContext context)
        {
            const string adminRoleName = "Admin";
            const string userRoleName = "User";

            context.Roles.AddOrUpdate(
                role => role.Name,
                new Role(adminRoleName),
                new Role(userRoleName)
                );

            context.SaveChanges();

            var vaults = new[]
            {
                new Vault("First vault", "First information vault with some data"),
                new Vault("Second vault", "Second information vault with some data"),
                new Vault("Third vault", "Third information vault with some data")
            };

            context.Vaults.AddOrUpdate(
                vault => vault.Name,
                vaults
                );

            context.SaveChanges();

            var ardminRole = context.Roles.First(x => x.Name == adminRoleName);
            var userRole = context.Roles.First(x => x.Name == userRoleName);

            const string userName1 = "admin@example.com";
            const string userName2 = "user@example.com";
            const string userName3 = "good.man@example.com";
            const string userName4 = "hodor@hodor.hodor";
            const string userName5 = "not.good.man@mail.ru";

            var users = new[]
            {
                new User(userName1, "admin", ardminRole),
                new User(userName2, "user", userRole),
                new User(userName3, "qwerty", userRole),
                new User(userName4, "hodor", ardminRole),
                new User(userName5, "123", userRole)
            };

            users[1].Vaults.Add(vaults[0]);
            users[1].Vaults.Add(vaults[1]);
            users[2].Vaults.Add(vaults[2]);
            users[4].Vaults.Add(vaults[0]);
            users[4].Vaults.Add(vaults[2]);

            context.Users.AddOrUpdate(
                user => user.Email,
                users
            );
        }
    }
}