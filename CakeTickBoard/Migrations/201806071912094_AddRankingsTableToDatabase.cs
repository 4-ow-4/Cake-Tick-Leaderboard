namespace CakeTickBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRankingsTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CakeRankings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RankName = c.String(),
                        LowerBoundPoints = c.Int(nullable: false),
                        UpperBoundPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CakeRankings");
        }
    }
}
