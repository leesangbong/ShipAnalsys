namespace ShipAnalsys.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ShipAnalsys.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ShipAnalsys.Models.ShipAnalsysContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShipAnalsys.Models.ShipAnalsysContext context)
        {

            context.ShipLists.AddOrUpdate(x => x.Id,
            new ShipList() { Id = 1, name = "BONA" },
            new ShipList() { Id = 2, name = "LAB021" },
             new ShipList() { Id = 3, name = "LAB031" }
            );


            //context.ShipDatas.AddOrUpdate(x => x.Id,

            //    new ShipData() { Id = 1, date = new DateTime(2015, 1, 1, 0, 0, 0), ShipListId = 1, speedVs = 13.20m, powerDel = 23233.2m, relWindDir = 23.4m, relWindSpd = 12.33m, headingGps = 122.7m, shaftRev = 98.1m, draughtAft = 11.5m, draughtFore = 12.5m, waterDepth = 567.5m, rudderAngle = 9.4m, seawaterTemp = 33.5m, flowMeterMeHfo = 33.91m, shaftTorque = 942.1m },
            //    new ShipData() { Id = 2, date = new DateTime(2015, 1, 1, 0, 0, 10), ShipListId = 2, speedVs = 13.20m, powerDel = 23233.2m, relWindDir = 23.4m, relWindSpd = 12.33m, headingGps = 122.7m, shaftRev = 98.1m, draughtAft = 11.5m, draughtFore = 12.5m, waterDepth = 567.5m, rudderAngle = 9.4m, seawaterTemp = 33.5m, flowMeterMeHfo = 33.91m, shaftTorque = 942.1m },
            //    new ShipData() { Id = 3, date = new DateTime(2015, 1, 1, 0, 0, 20), ShipListId = 3, speedVs = 13.20m, powerDel = 23233.2m, relWindDir = 23.4m, relWindSpd = 12.33m, headingGps = 122.7m, shaftRev = 98.1m, draughtAft = 11.5m, draughtFore = 12.5m, waterDepth = 567.5m, rudderAngle = 9.4m, seawaterTemp = 33.5m, flowMeterMeHfo = 33.91m, shaftTorque = 942.1m }
            //    );





            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
