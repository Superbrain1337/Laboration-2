namespace Laboration_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnotationsInPlayer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Name", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Name", c => c.String());
        }
    }
}
