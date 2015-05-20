namespace TankStudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogsAndPosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BlogID = c.Int(nullable: false),
                        DatePublished = c.DateTime(nullable: false),
                        Content = c.String(),
                        Title = c.String(),
                        CoverImageLink = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.BlogID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "BlogID", "dbo.Blogs");
            DropIndex("dbo.BlogPosts", new[] { "BlogID" });
            DropTable("dbo.BlogPosts");
            DropTable("dbo.Blogs");
        }
    }
}
