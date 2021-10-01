namespace Wasted.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIDAsPrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Foods");
            AddColumn("dbo.Foods", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Foods", "FoodName", c => c.String());
            AddPrimaryKey("dbo.Foods", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Foods");
            AlterColumn("dbo.Foods", "FoodName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Foods", "ID");
            AddPrimaryKey("dbo.Foods", "FoodName");
        }
    }
}
