namespace Wasted.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeButton1_Click : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Foods");
            AlterColumn("dbo.Foods", "FoodName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Foods", "FoodName");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Foods");
            AlterColumn("dbo.Foods", "FoodName", c => c.String());
            
        }
    }
}
