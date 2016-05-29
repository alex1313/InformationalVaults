namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddVaultAccessLogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VaultAccessLogs",
                c => new
                {
                    Id = c.Int(false, true),
                    DateTimeStamp = c.DateTime(false),
                    UserId = c.Int(false),
                    VaultId = c.Int(false),
                    IsAccessDenied = c.Boolean(false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, true)
                .ForeignKey("dbo.Vaults", t => t.VaultId, true)
                .Index(t => t.UserId)
                .Index(t => t.VaultId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.VaultAccessLogs", "VaultId", "dbo.Vaults");
            DropForeignKey("dbo.VaultAccessLogs", "UserId", "dbo.Users");
            DropIndex("dbo.VaultAccessLogs", new[] {"VaultId"});
            DropIndex("dbo.VaultAccessLogs", new[] {"UserId"});
            DropTable("dbo.VaultAccessLogs");
        }
    }
}