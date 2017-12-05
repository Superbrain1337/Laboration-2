namespace Laboration_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scores", "Levels_LevelId", "dbo.Levels");
            DropIndex("dbo.Scores", new[] { "Levels_LevelId" });
            AlterColumn("dbo.Levels", "Name", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Players", "Name", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Scores", "Levels_LevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Scores", "Levels_LevelId");
            AddForeignKey("dbo.Scores", "Levels_LevelId", "dbo.Levels", "LevelId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "Levels_LevelId", "dbo.Levels");
            DropIndex("dbo.Scores", new[] { "Levels_LevelId" });
            AlterColumn("dbo.Scores", "Levels_LevelId", c => c.Int());
            AlterColumn("dbo.Players", "Name", c => c.String(maxLength: 32));
            AlterColumn("dbo.Levels", "Name", c => c.String(maxLength: 4000));
            CreateIndex("dbo.Scores", "Levels_LevelId");
            AddForeignKey("dbo.Scores", "Levels_LevelId", "dbo.Levels", "LevelId");
        }
    }
}
