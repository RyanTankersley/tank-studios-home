namespace TankStudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageLinkToEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "ImageType", c => c.Int(nullable: false));
            DropColumn("dbo.Blogs", "ImageLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "ImageLink", c => c.String());
            DropColumn("dbo.Blogs", "ImageType");
        }
    }
}
