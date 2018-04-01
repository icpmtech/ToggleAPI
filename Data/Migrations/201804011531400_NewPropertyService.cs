namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPropertyService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Name");
        }
    }
}
