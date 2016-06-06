namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    using DomainModel.Definitions;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(false, true),
                    Email = c.String(),
                    Password = c.String(),
                    RoleId = c.Int(false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, true)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Vaults",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                    Description = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UserVault",
                c => new
                {
                    UserId = c.Int(false),
                    VaultId = c.Int(false)
                })
                .PrimaryKey(t => new {t.UserId, t.VaultId})
                .ForeignKey("dbo.Users", t => t.UserId, true)
                .ForeignKey("dbo.Vaults", t => t.VaultId, true)
                .Index(t => t.UserId)
                .Index(t => t.VaultId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.UserVault", "VaultId", "dbo.Vaults");
            DropForeignKey("dbo.UserVault", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.UserVault", new[] {"VaultId"});
            DropIndex("dbo.UserVault", new[] {"UserId"});
            DropIndex("dbo.Users", new[] {"RoleId"});
            DropTable("dbo.UserVault");
            DropTable("dbo.Vaults");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}