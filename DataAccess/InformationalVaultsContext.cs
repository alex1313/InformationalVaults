namespace DataAccess
{
    using System.Data.Entity;
    using DomainModel.Entities;

    public class InformationalVaultsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Vault> Vaults { get; set; }
        public DbSet<VaultAccessLog> VaultAccessLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(v => v.Vaults)
                .WithMany(u => u.Users)
                .Map(uv =>
                {
                    uv.MapLeftKey("UserId");
                    uv.MapRightKey("VaultId");
                    uv.ToTable("UserVault");
                });
        }
    }
}