namespace Laboration_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScoreMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scores", "Levels_LevelId", "dbo.Levels");
            DropIndex("dbo.Scores", new[] { "Levels_LevelId" });
            AlterColumn("dbo.Scores", "Levels_LevelId", c => c.Int());
            CreateIndex("dbo.Scores", "Levels_LevelId");
            AddForeignKey("dbo.Scores", "Levels_LevelId", "dbo.Levels", "LevelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "Levels_LevelId", "dbo.Levels");
            DropIndex("dbo.Scores", new[] { "Levels_LevelId" });
            AlterColumn("dbo.Scores", "Levels_LevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Scores", "Levels_LevelId");
            AddForeignKey("dbo.Scores", "Levels_LevelId", "dbo.Levels", "LevelId", cascadeDelete: true);
        }
    }
}
