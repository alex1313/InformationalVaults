namespace DataAccess
{
    using System.Data.Entity;
    using DomainModel.Entities;

    public class InformationalVaultsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Vault> Vaults { get; set; }
    }
}