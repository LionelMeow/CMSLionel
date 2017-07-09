namespace CMSLionel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        ContainerName = c.String(nullable: false),
                        ContainerDescription = c.String(nullable: false),
                        ContainerWeight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmployeePassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        ShipID = c.Int(nullable: false),
                        ContainerID = c.Int(nullable: false),
                        ChargePrice = c.Double(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.Containers", t => t.ContainerID, cascadeDelete: true)
                .ForeignKey("dbo.Ships", t => t.ShipID, cascadeDelete: true)
                .Index(t => t.ShipID)
                .Index(t => t.ContainerID);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        ShipName = c.String(nullable: false),
                        ShipDescription = c.String(nullable: false),
                        NumberOfContainersCarried = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipID);
            
            CreateTable(
                "dbo.Shipyards",
                c => new
                    {
                        ShipyardID = c.Int(nullable: false, identity: true),
                        ShipYardName = c.String(),
                        CurrentNumberOfShipsDocked = c.Int(nullable: false),
                        ShipYardDockNumber = c.Int(nullable: false),
                        TotalNumberOfContainers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipyardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "ShipID", "dbo.Ships");
            DropForeignKey("dbo.Schedules", "ContainerID", "dbo.Containers");
            DropIndex("dbo.Schedules", new[] { "ContainerID" });
            DropIndex("dbo.Schedules", new[] { "ShipID" });
            DropTable("dbo.Shipyards");
            DropTable("dbo.Ships");
            DropTable("dbo.Schedules");
            DropTable("dbo.Employees");
            DropTable("dbo.Containers");
        }
    }
}
