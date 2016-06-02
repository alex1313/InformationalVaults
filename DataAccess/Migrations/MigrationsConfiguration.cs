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

            var ardminRoleId = context.Roles.First(x => x.Name == adminRoleName).Id;
            var userRoleId = context.Roles.First(x => x.Name == userRoleName).Id;

            const string userName1 = "user@example.com";
            const string userName2 = "good.man@example.com";
            const string userName3 = "hodor@hodor.hodor";
            const string userName4 = "not.good.man@mail.ru";
            const string userName5 = "admin@example.com";

            var users = new[]
            {
                new User(userName1, "user", ardminRoleId),
                new User(userName2, "qwerty", userRoleId),
                new User(userName3, "hodor", userRoleId),
                new User(userName4, "123", ardminRoleId),
                new User(userName5, "admin", userRoleId)
            };

            context.Users.AddOrUpdate(
                user => user.Email,
                users
            );

            context.SaveChanges();

            var vaults = new[]
            {
                new Vault("First vault", "First information vault with some data"),
                new Vault("Second vault", "Second information vault with some data"),
                new Vault("Third vault", "Third information vault with some data")
            };

            vaults[0].AdminId = users[0].Id;
            vaults[1].AdminId = users[1].Id;
            vaults[2].AdminId = users[2].Id;

            vaults[0].Users.Add(users[1]);
            vaults[0].Users.Add(users[2]);
            vaults[0].Users.Add(users[3]);
            vaults[1].Users.Add(users[0]);
            vaults[1].Users.Add(users[3]);
            vaults[2].Users.Add(users[3]);

            context.Vaults.AddOrUpdate(
                vault => vault.Name,
                vaults
                );
        }
    }
}