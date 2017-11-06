namespace Robota.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persons", "FullName", c => c.String());
            DropColumn("dbo.Persons", "FirstName");
            DropColumn("dbo.Persons", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Persons", "LastName", c => c.String());
            AddColumn("dbo.Persons", "FirstName", c => c.String());
            DropColumn("dbo.Persons", "FullName");
        }
    }
}
