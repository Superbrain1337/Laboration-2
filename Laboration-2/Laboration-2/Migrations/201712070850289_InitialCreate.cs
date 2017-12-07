namespace Laboration_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        AmountOfMoves = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LevelId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        Level_LevelId = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Levels", t => t.Level_LevelId)
                .Index(t => t.Level_LevelId);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ScoreId = c.Int(nullable: false, identity: true),
                        AmountOfMovesUsed = c.Int(nullable: false),
                        Levels_LevelId = c.Int(nullable: false),
                        Player_PlayerId = c.Int(),
                    })
                .PrimaryKey(t => t.ScoreId)
                .ForeignKey("dbo.Levels", t => t.Levels_LevelId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.Player_PlayerId)
                .Index(t => t.Levels_LevelId)
                .Index(t => t.Player_PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "Level_LevelId", "dbo.Levels");
            DropForeignKey("dbo.Scores", "Player_PlayerId", "dbo.Players");
            DropForeignKey("dbo.Scores", "Levels_LevelId", "dbo.Levels");
            DropIndex("dbo.Scores", new[] { "Player_PlayerId" });
            DropIndex("dbo.Scores", new[] { "Levels_LevelId" });
            DropIndex("dbo.Players", new[] { "Level_LevelId" });
            DropTable("dbo.Scores");
            DropTable("dbo.Players");
            DropTable("dbo.Levels");
        }
    }
}
