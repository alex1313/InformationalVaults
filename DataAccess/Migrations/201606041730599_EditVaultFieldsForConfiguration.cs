namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EditVaultFieldsForConfiguration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vaults", "OpenTime", c => c.Time(precision: 7));
            AddColumn("dbo.Vaults", "CloseTime", c => c.Time(precision: 7));
            AlterColumn("dbo.Vaults", "Name", c => c.String(false));
            AlterColumn("dbo.Vaults", "Description", c => c.String(false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Vaults", "Description", c => c.String());
            AlterColumn("dbo.Vaults", "Name", c => c.String());
            DropColumn("dbo.Vaults", "CloseTime");
            DropColumn("dbo.Vaults", "OpenTime");
        }
    }
}