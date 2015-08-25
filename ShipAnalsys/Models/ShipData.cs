using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipAnalsys.Models
{
    public class ShipData
    {
        public Int64 Id { get; set; }
        public DateTime date { get; set; }
        public decimal speedVs { get; set; }
        public decimal powerDel { get; set; }
        public decimal relWindDir { get; set; }
        public decimal relWindSpd { get; set; }
        public decimal speedVg { get; set; }
        public decimal headingGps { get; set; }
        public decimal shaftRev { get; set; }
        public decimal draughtFore { get; set; }
        public decimal draughtAft { get; set; }
        public decimal waterDepth { get; set; }
        public decimal rudderAngle { get; set; }
        public decimal seawaterTemp { get; set; }
        public decimal flowMeterMeHfo { get; set; }
        public decimal shaftTorque { get; set; }


        public int ShipListId { get; set; }
        public ShipList ShipLists { get; set; }
    }
}