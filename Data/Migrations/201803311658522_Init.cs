namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Identifier = c.Guid(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Identifier);
            
            CreateTable(
                "dbo.Toggles",
                c => new
                    {
                        Identifier = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Identifier);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Identifier = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IdToggle = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Identifier)
                .ForeignKey("dbo.Toggles", t => t.IdToggle, cascadeDelete: true)
                .Index(t => t.IdToggle);
            
            CreateTable(
                "dbo.ToggleServices",
                c => new
                    {
                        Toggle_Identifier = c.Guid(nullable: false),
                        Service_Identifier = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Toggle_Identifier, t.Service_Identifier })
                .ForeignKey("dbo.Toggles", t => t.Toggle_Identifier, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_Identifier, cascadeDelete: true)
                .Index(t => t.Toggle_Identifier)
                .Index(t => t.Service_Identifier);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.States", "IdToggle", "dbo.Toggles");
            DropForeignKey("dbo.ToggleServices", "Service_Identifier", "dbo.Services");
            DropForeignKey("dbo.ToggleServices", "Toggle_Identifier", "dbo.Toggles");
            DropIndex("dbo.ToggleServices", new[] { "Service_Identifier" });
            DropIndex("dbo.ToggleServices", new[] { "Toggle_Identifier" });
            DropIndex("dbo.States", new[] { "IdToggle" });
            DropTable("dbo.ToggleServices");
            DropTable("dbo.States");
            DropTable("dbo.Toggles");
            DropTable("dbo.Services");
        }
    }
}
