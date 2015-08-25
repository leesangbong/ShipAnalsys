namespace ShipAnalsys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipDatas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        date = c.DateTime(),
                        speedVs = c.Decimal(precision: 5, scale: 2),
                        powerDel = c.Decimal(precision: 8, scale: 2),
                        relWindDir = c.Decimal(precision: 5, scale: 2),
                        relWindSpd = c.Decimal(precision: 6, scale: 2),
                        speedVg = c.Decimal(precision: 5, scale: 2),
                        headingGps = c.Decimal(precision: 5, scale: 2),
                        shaftRev = c.Decimal(precision: 6, scale: 2),
                        draughtFore = c.Decimal(precision: 5, scale: 2),
                        draughtAft = c.Decimal(precision: 5, scale: 2),
                        waterDepth = c.Decimal(precision: 8, scale: 2),
                        rudderAngle = c.Decimal(precision: 5, scale: 2),
                        seawaterTemp = c.Decimal(precision: 5, scale: 2),
                        flowMeterMeHfo = c.Decimal(precision: 4, scale: 2),
                        shaftTorque = c.Decimal(precision: 6, scale: 2),
                        ShipListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShipLists", t => t.ShipListId, cascadeDelete: true)
                .Index(t => t.ShipListId);
            
            CreateTable(
                "dbo.ShipLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipDatas", "ShipListId", "dbo.ShipLists");
            DropIndex("dbo.ShipDatas", new[] { "ShipListId" });
            DropTable("dbo.ShipLists");
            DropTable("dbo.ShipDatas");
        }
    }
}
