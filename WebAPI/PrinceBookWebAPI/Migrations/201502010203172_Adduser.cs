namespace PrinceBookWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adduser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        EmailAddress = c.String(),
                        IsMentor = c.Boolean(nullable: false),
                        LocationLatitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationLongitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SelectedIndustryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
