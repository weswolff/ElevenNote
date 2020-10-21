namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Note", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "CustomerId");
            AddForeignKey("dbo.Note", "CustomerId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "CustomerId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CustomerId" });
            DropColumn("dbo.Note", "CustomerId");
            DropTable("dbo.Category");
        }
    }
}
