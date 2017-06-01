namespace DKTFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverRaces",
                c => new
                    {
                        DriverRaceID = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        Driver_DriverID = c.Int(),
                        Race_RaceID = c.Int(),
                        Driver_DriverID1 = c.Int(),
                        Race_RaceID1 = c.Int(),
                    })
                .PrimaryKey(t => t.DriverRaceID)
                .ForeignKey("dbo.Drivers", t => t.Driver_DriverID1)
                .ForeignKey("dbo.Races", t => t.Race_RaceID1)
                .Index(t => t.Driver_DriverID1)
                .Index(t => t.Race_RaceID1);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverID = c.Int(nullable: false, identity: true),
                        DriverName = c.String(),
                        DriverNumber = c.String(),
                    })
                .PrimaryKey(t => t.DriverID);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        RaceID = c.Int(nullable: false, identity: true),
                        RaceDate = c.DateTime(nullable: false),
                        RaceName = c.String(),
                        RaceClass = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RaceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DriverRaces", "Race_RaceID1", "dbo.Races");
            DropForeignKey("dbo.DriverRaces", "Driver_DriverID1", "dbo.Drivers");
            DropIndex("dbo.DriverRaces", new[] { "Race_RaceID1" });
            DropIndex("dbo.DriverRaces", new[] { "Driver_DriverID1" });
            DropTable("dbo.Races");
            DropTable("dbo.Drivers");
            DropTable("dbo.DriverRaces");
        }
    }
}
