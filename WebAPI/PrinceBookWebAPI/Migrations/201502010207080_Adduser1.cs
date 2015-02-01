namespace PrinceBookWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adduser1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "IsMentor", c => c.Boolean());
            AlterColumn("dbo.Users", "LocationLatitude", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Users", "LocationLongitude", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Users", "SelectedIndustryID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "SelectedIndustryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "LocationLongitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "LocationLatitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "IsMentor", c => c.Boolean(nullable: false));
        }
    }
}
