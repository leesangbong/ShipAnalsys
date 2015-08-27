using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipAnalsys.Models
{
    public class ShipAnalsysContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ShipAnalsysContext() : base("name=ShipAnalsysContext")
        {
        }

        public DbSet<ShipList> ShipLists { get; set; }

        public DbSet<ShipData> ShipDatas { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            modelBuilder.Entity<ShipList>().HasMany(d => d.ShipDatas).WithRequired(l => l.ShipLists);

            modelBuilder.Entity<ShipList>().HasKey(l => l.Id).Property(l => l.Id).IsRequired();
            modelBuilder.Entity<ShipList>().Property(l => l.name).IsRequired();

            modelBuilder.Entity<ShipData>().Property(d => d.date).HasColumnType("datetime").IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.speedVs).HasPrecision(5, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.powerDel).HasPrecision(8, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.relWindDir).HasPrecision(5, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.relWindSpd).HasPrecision(6, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.speedVg).HasPrecision(5, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.headingGps).HasPrecision(5, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.shaftRev).HasPrecision(6, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.draughtFore).HasPrecision(5, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.draughtAft).HasPrecision(5, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.waterDepth).HasPrecision(8, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.rudderAngle).HasPrecision(5, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.seawaterTemp).HasPrecision(5, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.flowMeterMeHfo).HasPrecision(4, 2).IsOptional();
            modelBuilder.Entity<ShipData>().Property(d => d.shaftTorque).HasPrecision(6, 2).IsOptional();

        }
    }

}
