namespace Robota.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSexToPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persons", "Address", c => c.String());
            AddColumn("dbo.Persons", "Sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Persons", "Sex");
            DropColumn("dbo.Persons", "Address");
        }
    }
}
