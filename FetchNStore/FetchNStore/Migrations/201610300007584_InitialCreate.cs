namespace FetchNStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ResponseModels", newName: "Responses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Responses", newName: "ResponseModels");
        }
    }
}
