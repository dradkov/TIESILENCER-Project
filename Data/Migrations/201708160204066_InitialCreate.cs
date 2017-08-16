namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerDbEntities",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ScoreId = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        Player_PlayerId = c.Int(),
                    })
                .PrimaryKey(t => t.ScoreId)
                .ForeignKey("dbo.PlayerDbEntities", t => t.Player_PlayerId)
                .Index(t => t.Player_PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "Player_PlayerId", "dbo.PlayerDbEntities");
            DropIndex("dbo.Scores", new[] { "Player_PlayerId" });
            DropTable("dbo.Scores");
            DropTable("dbo.PlayerDbEntities");
        }
    }
}
