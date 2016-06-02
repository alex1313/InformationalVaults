namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddVaultAdminRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vaults", "AdminId", c => c.Int());
            CreateIndex("dbo.Vaults", "AdminId");
            AddForeignKey("dbo.Vaults", "AdminId", "dbo.Users", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Vaults", "AdminId", "dbo.Users");
            DropIndex("dbo.Vaults", new[] {"AdminId"});
            DropColumn("dbo.Vaults", "AdminId");
        }
    }
}