namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Todoes", "CreatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Todoes", "CreatedBy", c => c.Int(nullable: false));
        }
    }
}
