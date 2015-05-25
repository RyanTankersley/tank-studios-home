namespace TankStudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogPostFinished : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPosts", "SubTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogPosts", "SubTitle");
        }
    }
}
