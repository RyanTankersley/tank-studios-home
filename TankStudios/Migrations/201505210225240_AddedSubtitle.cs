namespace TankStudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubtitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "SubTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "SubTitle");
        }
    }
}
