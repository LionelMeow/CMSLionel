namespace CMSLionel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "DestinationShipyardID", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "ArrivalShipyardID", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "EmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String(nullable: false));
            CreateIndex("dbo.Schedules", "DestinationShipyardID");
            CreateIndex("dbo.Schedules", "ArrivalShipyardID");
            CreateIndex("dbo.Schedules", "EmployeeID");
            AddForeignKey("dbo.Schedules", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: false);
            AddForeignKey("dbo.Schedules", "DestinationShipyardID", "dbo.Shipyards", "ShipyardID", cascadeDelete: false);
            AddForeignKey("dbo.Schedules", "ArrivalShipyardID", "dbo.Shipyards", "ShipyardID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "ArrivalShipyardID", "dbo.Shipyards");
            DropForeignKey("dbo.Schedules", "DestinationShipyardID", "dbo.Shipyards");
            DropForeignKey("dbo.Schedules", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Schedules", new[] { "EmployeeID" });
            DropIndex("dbo.Schedules", new[] { "ArrivalShipyardID" });
            DropIndex("dbo.Schedules", new[] { "DestinationShipyardID" });
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String());
            DropColumn("dbo.Schedules", "EmployeeID");
            DropColumn("dbo.Schedules", "ArrivalShipyardID");
            DropColumn("dbo.Schedules", "DestinationShipyardID");
        }
    }
}
