namespace CakeTickBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserId_ToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserId", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserId");
        }
    }
}
