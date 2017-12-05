namespace Laboration_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnotationEverything : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Levels", "Name", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Levels", "Name", c => c.String());
        }
    }
}
