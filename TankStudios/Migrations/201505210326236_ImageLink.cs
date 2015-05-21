namespace TankStudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "ImageLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "ImageLink");
        }
    }
}
